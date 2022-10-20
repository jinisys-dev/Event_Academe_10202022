using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Utilities.BusinessLayer
{
    public class BackUp
    {
        public BackUp()
        {

        }
        private ArrayList mDatabases;
        public ArrayList Databases
        {
            get
            {
                return mDatabases;
            }
            set
            {
                mDatabases = value;
            }
        }

    }



}