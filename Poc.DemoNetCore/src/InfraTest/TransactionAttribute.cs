using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraTest
{
    public class TransactionAttribute  : Attribute, ITestAction
    {
       

        public ActionTargets Targets { get; } = ActionTargets.Test;

        public void BeforeTest(ITest test)
        {
            StartUp.Db.Database.BeginTransaction();
        }

        public void AfterTest(ITest test)
        {
            StartUp.Db.Database.RollbackTransaction();
        }
    }
}
