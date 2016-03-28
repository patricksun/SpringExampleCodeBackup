using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using BLL.Interface;

namespace WinClient.Presenters
{
    public class Customer : IPresenter
    {
        private IBLL _customerBLL = null;
        
        public Customer()
        {
            _customerBLL = (IBLL)WinClient.ApplicationContext["CustomerBLL"];
        }

        #region IPresenter Members

        public DataTable GetData(string ID)
        {
            if (ID == null || ID.Length == 0)
            {
                return _customerBLL.GetAll();
            }
            else
            {
                return _customerBLL.GetById(ID);
            }
        }
       

        public bool SaveOrUpdate(DataTable entity)
        {
            return _customerBLL.SaveOrUpdate(entity);
        }

        #endregion
    }
}
