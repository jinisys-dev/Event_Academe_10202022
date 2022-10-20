using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class HousekeepingStepProcedure : DataSet
    {
        private string mId    ;
        public string Id
        {
            get { return mId; }
            set { mId = value;  }
        }
        private string mName         ;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        private bool mUseSoundFile  ;
        public bool UseSoundFile
        {
            get { return mUseSoundFile; }
            set { mUseSoundFile = value; }
        }
    private string mSoundFile     ;
        public string SoundFile
        {
            get { return mSoundFile; }
            set { mSoundFile = value; }
        }
    private string mTextToSpeak   ;
        public string TextToSpeak
        {
            get { return mTextToSpeak; }
            set { mTextToSpeak = value; }
        }
    private int mRank  ;
        public int Rank
        {
            get { return mRank; }
            set { mRank = value; }
        }
    private bool misBefore;
        public bool isBefore
        {
            get { return misBefore; }
            set { misBefore = value; }
        }
    private int mmaxDigit    ;
        public int maxDigit
        {
            get { return mmaxDigit; }
            set { mmaxDigit = value; }
        }
    private int mExpectedDigit;
        public int ExpectedDigit
        {
            get { return mExpectedDigit; }
            set { mExpectedDigit = value; }
        }
 }

}
