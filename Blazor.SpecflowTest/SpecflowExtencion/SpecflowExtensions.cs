using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Blazor.SpeckflowTest.SpecflowExtencion.CommonBase
{
    public static class SpecFlowExtensions
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Gherkin data table has no rows");

            if (table.Rows.First().Count != 2)
                throw new InvalidOperationException($"Gherkin data table must have exactly 2 columns.");

            return table.Rows.ToDictionary(row => row[0], row => row[1]);
        }
    }
}
