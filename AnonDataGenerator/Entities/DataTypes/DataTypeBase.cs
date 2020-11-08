using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnonDataGenerator.Entities
{
    public abstract class DataTypeBase
    {
        protected int _numberToGenerate;
        protected List<string> _rtnList = new List<string>();

        public DataTypeBase(int numberToGenerate)
        {
            _numberToGenerate = numberToGenerate;
        }

        public virtual Task<List<string>> GeneratedData()
        {
            if (_rtnList.Count != 0)
                return Task.FromResult(_rtnList);

            for (var i = 0; i < _numberToGenerate; i++) {
                _rtnList.Add($"Test {i} - {this.GetType().Name}");
            }

            return Task.FromResult(_rtnList);
        }
    }
}
