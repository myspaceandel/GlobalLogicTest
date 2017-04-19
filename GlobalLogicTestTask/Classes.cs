using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLogicTestTask
{
    [Serializable]
    class user_directory
    {
        public user_directory[] SubFolders;
        public user_file[] Files { get; set; }
        public string Name { get; set; }

        
    }
    [Serializable]
    class user_file
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
}
