using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using BLL.Interface;

namespace WinClient.Presenters
{
    public class Employee : IPresenter
    {
        private IBLL _employeeBLL = null;

        public Employee()
        {
            _employeeBLL = (IBLL)WinClient.ApplicationContext["EmployeeBLL"];
        }

        #region IPresenter Members

        public DataTable GetData(string ID)
        {
            if (ID == null || ID.Length == 0 )
            {
                return _employeeBLL.GetAll();
            }
            else
            {
                return _employeeBLL.GetById(ID);
            }
        }
       

        public bool SaveOrUpdate(DataTable entity)
        {
            return _employeeBLL.SaveOrUpdate(entity);
        }

        #endregion
    }
}
