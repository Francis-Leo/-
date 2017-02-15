using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class pictureEntity
    {
        private int _picid;
        private string _path;
        private string _name;
        private string _chapter;
        private string _state;
        private string _owner;
        private string _other;

        #region picture实体
        public int picid
        {
            get
            {
                return _picid;
            }
            set
            {
                _picid = value;
            }
        }
        public string path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string chapter
        {
            get
            {
                return _chapter;
            }
            set
            {
                _chapter = value;
            }
        }
        public string state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        public string owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }
        public string other
        {
            get
            {
                return _other;
            }
            set
            {
                _other = value;
            }
        }
        #endregion
        
    }
}