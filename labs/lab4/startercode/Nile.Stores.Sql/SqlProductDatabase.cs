/*
 * ITSE 1430
 * William Sarawichitr
 * 4-29-20
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        protected override Product AddCore ( Product product )
        {
            throw new NotImplementedException();
        }

        protected override Product FindByName ( string title )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            throw new NotImplementedException();
        }

        protected override Product GetCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            throw new NotImplementedException();
        }
    }
}
