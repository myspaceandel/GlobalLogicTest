using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalLogicTestTask
{
    public partial class MainForm : Form
    {
        #region Serialize
        private user_directory get_dir_info(string root) {
            List<user_directory> subfolders_buf = new List<user_directory>();
            var dir = new user_directory();
            var dir_info = new DirectoryInfo(root);
            dir.Name = dir_info.Name;
            dir.Files = get_file_info(root).ToArray();
            foreach (var curr_dir in Directory.GetDirectories(root)) {
                subfolders_buf.Add(get_dir_info(curr_dir));
            }
            dir.SubFolders = subfolders_buf.ToArray();
            return dir;
        }
        private IEnumerable<user_file> get_file_info(string dir)
        {
            foreach (var curr_file in Directory.GetFiles(dir))
            {
                var file_info = new FileInfo(curr_file);
                var file = new user_file
                {
                    Name = file_info.Name,
                    Data = File.ReadAllBytes(curr_file)
                };
                yield return file;
            }
        }
        #endregion
        private void Deserialize(user_directory node_dir) {
            Directory.CreateDirectory(node_dir.Name);
            foreach (var curr_file in node_dir.Files) {
                File.WriteAllBytes(node_dir.Name + "//" + curr_file.Name, curr_file.Data);
            }
            foreach (var curr_dir in node_dir.SubFolders) {
                curr_dir.Name = node_dir.Name + "//" + curr_dir.Name;
                Deserialize(curr_dir);
            }
        }
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void serialize_Click(object sender, EventArgs e)
        {
            if (openFolderToSer.ShowDialog() == DialogResult.OK)
            {
                string path_string = openFolderToSer.SelectedPath;

                var node_dir = new DirectoryInfo(path_string);

                FileStream fs = new FileStream(node_dir.Name + ".dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, get_dir_info(path_string));
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
        private void deserialize_Click(object sender, EventArgs e)
        {
            if (openFileToDes.ShowDialog() == DialogResult.OK)
            {
                var binaryFormatter = new BinaryFormatter();
                FileStream fs = new FileStream(openFileToDes.FileName, FileMode.Open, FileAccess.Read);
                try
                {
                    Deserialize((user_directory)binaryFormatter.Deserialize(fs));
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show("Failed to deserialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }
}
