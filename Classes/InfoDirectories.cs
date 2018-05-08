using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_Work.Classes
{
    class InfoDirectories
    {
        private string _directory;
        private string[] _childDirectories;

        public InfoDirectories(string directory, string[] childDirectories)
        {
            this._directory = directory;
            this._childDirectories = childDirectories;
        }


        public string Directory
        {
            get
            {
                return this._directory;
            }
            set
            {
                this._directory = value;
            }
        }
        public string[] ChildDirectories
        {
            get
            {
                return this._childDirectories;
            }
            set
            {
                this._childDirectories = value;
            }
        }
    }
}
