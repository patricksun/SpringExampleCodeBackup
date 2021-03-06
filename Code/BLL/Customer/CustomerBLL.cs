using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL.Interface;

namespace BLL.Customer
{
    public class CustomerBLL : BaseBLL
    {
        private IDAL _customerDAL = null;

        public CustomerBLL()
            : base()
        {
            //_customerDAL = (IDAL)applicationContext["CustomerDAL"];
            _customerDAL = (IDAL)applicationContext["CustomerDALWithAdvice"];
        }

        #region IBLL Members

        public override DataTable GetAll()
        {
            return _customerDAL.GetAll();
        }

        public override DataTable GetById(string ID)
        {
            return _customerDAL.GetById(ID);
        }

        public override bool SaveOrUpdate(DataTable entity)
        {
            return _customerDAL.SaveOrUpdate(entity);
        }

        #endregion
    }
}
