using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnonDataGenerator.Entities
{
    public class UUID : DataTypeBase
    {
        public UUID(int numberToGenerate) : base(numberToGenerate) { }

        public override Task<List<string>> GeneratedData()
        {
            if (_rtnList.Count != 0)
                return Task.FromResult(_rtnList);

            for (var i = 0; i < _numberToGenerate; i++)
            {
                _rtnList.Add(Guid.NewGuid().ToString());
            }

            return Task.FromResult(_rtnList);
        }
    }
}
