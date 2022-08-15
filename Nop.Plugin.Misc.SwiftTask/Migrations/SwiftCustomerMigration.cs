using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.SwiftTask.Domain;

namespace Nop.Plugin.Misc.SwiftTask.Migration
{
    [NopMigration("2022/08/15 08:40:55:1687541", "Swift Customer Migration", MigrationProcessType.Installation)]
    public class SwiftCustomerMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<SwiftCustomerEntity>();
        }
    }
}
