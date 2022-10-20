/***
 * Author: jlo
 * Date: 8-24-2010
 * Description: This object will allow the translation of words found in folio plus
 ***/

using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Utilities.DataAccessLayer;
using System.Data;

namespace Jinisys.Hotel.Utilities.BusinessLayer
{
    public class Translator
    {
        #region "VARIABLES"
        private static TranslatorDAO loTranslatorDAO = new TranslatorDAO();        
        #endregion
        public Translator()
        {
        }
        /// <summary>
        /// Returns a translation of word/s if found in the database else returns an exception
        /// </summary>
        /// <param name="pComponent">component name</param>
        /// <returns>translated value</returns>
        public static string getTranslation(string pValue)
        {
            try
            {
                return loTranslatorDAO.getTranslation(pValue);
            }
            catch (Exception ex)
            {
                throw new Exception("Error @Translator\r\n" + ex.Message);
            }
        }
        /// <summary>
        /// Returns the set of translations from the database
        /// </summary>
        /// <returns>datatable of translations</returns>
        public DataTable getTranslations()
        {
            try
            {
                return loTranslatorDAO.getTranslations();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @Translator\r\n" + ex.Message);
            }
        }
    }
}
