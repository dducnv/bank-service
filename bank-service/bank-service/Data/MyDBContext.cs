using bank_service.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManage.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext():base("name=EcommerceContext")
        {

        }
    }
}