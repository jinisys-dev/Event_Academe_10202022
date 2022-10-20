using System;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace Jinisys.Hotel.ApplicationManager
{
    class FolioPlusRegistry
    {
        private Hashtable m_types =new Hashtable();
        //private System.Windows.Forms.Form m_FolioUIs=null;
        public IEnumerator FolioUIs()
        {
            return m_types.Values.GetEnumerator();
        }
        public Type GetTypeByName(string StringTypeName)
        {
            return m_types[StringTypeName] as Type;
        }
        public IEnumerator FolioUINames()
        {
            return m_types.Keys.GetEnumerator();
        }
        public bool RegisterFolioTypes(string file_name)
        {
            Assembly new_assembly;
            Type[] types;
            new_assembly = Assembly.LoadFrom(file_name);
            types = new_assembly.GetTypes();
            foreach (Type t in types)
            {
                if (!t.IsAbstract)
                {
                    if (!m_types.ContainsValue(t))
                    {
                        if (!m_types.Contains(t.FullName))
                            m_types.Add(t.FullName, t);
                    }
                  
                }
            }
            return true;
        }
        public Object CreateObject(string type_name,  object[] param,Type[] paramTypes)
        {
            Type obj_type = null;
            ConstructorInfo ci = null;
            if (!m_types.Contains(type_name))
                return null;
            obj_type = (Type)m_types[type_name];
            try
            {
                ci = obj_type.GetConstructor(paramTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Object o ;
            if(param!=null)
                o= ci.Invoke(param);
            else
                o = ci.Invoke(null);

            return o ;
        }

        public Form CreateObject(string type_name,Type[] paramTypes,object[]param)
        {
            Type form_type=null;
            ConstructorInfo ci = null;
            if(!m_types.Contains(type_name))
                return null;
            form_type=(Type)m_types[type_name];
            try
            {
                ci = form_type.GetConstructor(paramTypes);
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; 
            }
            Object o = ci.Invoke(param);
            return o as Form;
        }

        public Object CreateObject(string type_name)
        {
            Type form_type = null;
            ConstructorInfo ci = null;
            if (!m_types.Contains(type_name))
                return null;
            form_type = (Type)m_types[type_name];
            try
            {
                ci = form_type.GetConstructor(System.Type.EmptyTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            Object o = ci.Invoke(null);
            return o;
        }
    }
    
}
