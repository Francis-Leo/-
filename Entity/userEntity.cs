using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class userEntity
    {
        private int _uid;
        private string _name;
        private string _password;
        private string _grade;
        private int _amount;
        private string _friends;
        private string _state;
        private string _rank;
        private string _other;

        #region user实体
        public int uid
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
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
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string grade
        {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
            }
        }
        public int amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public string friends
        {
            get
            {
                return _friends;
            }
            set
            {
                _friends = value;
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
        public string rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
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