using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.SwiftTask.Domain;

namespace Nop.Plugin.Misc.SwiftTask.Mapping.Builders
{
    public class SwiftCustomerEntityBuilder : NopEntityBuilder<SwiftCustomerEntity>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(SwiftCustomerEntity.CustomerId)).AsInt32().PrimaryKey()
            //map the additional properties as foreign keys
            .WithColumn(nameof(SwiftCustomerEntity.CustomerName)).AsString(200)
            .WithColumn(nameof(SwiftCustomerEntity.AgeRange)).AsString(20)
            //avoiding truncation/failure
            //so we set the same max length used in the product name
            .WithColumn(nameof(SwiftCustomerEntity.IsValid)).AsInt32();
        }
    }
}
