using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cart.Business.Validations.BaseValidation
{
    public abstract class ValidationBase
    {
        private string _value;
        private List<Validation> _listMessage;
        private string _field;
        private int _min;
        private int _max;
        private string _equal;

        public ValidationBase Rules<T>(T Value, string Field)
        {           
            _value = Value.ToString();
            _field = Field;

            if (_listMessage == null) _listMessage = new List<Validation>();
            
            return this;
        }

        public ValidationBase NotEmpty(string Message)
        {
            if (string.IsNullOrEmpty(_value)) _listMessage.Add(new Validation { Message = Message, Field = ""});
            return this;
        }

        public ValidationBase Length(int Min, int Max, string Message)
        {
            _min = Min;
            _max = Max;

            if (_value.Length < Min) _listMessage.Add(BuildMessage(Message));
            if (_value.Length > Max) _listMessage.Add(BuildMessage(Message));
            return this;
        }

        public void WhenEqual(bool expressao, Action Function)
        {
            if (expressao) Function();
        }

        public ValidationBase Equal<T>(T Values, string Message)
        {
            if(Values==null) return this; 
            
            _equal = Values.ToString();

            if(Values.ToString() != _value)
            {
                _listMessage.Add(BuildMessage(Message));
            }

            return this;
        }

        public ValidationBase BiggerThen(int Values, string Message)
        {
            if (!OnlyNumber(_value)) throw new Exception("Value is not interge valid in LessThan->ValidationBase");

            if (int.Parse(_value) > Values) _listMessage.Add(BuildMessage(Message));    
            return this;
        }

        public ValidationBase LessThan(int Values, string Message)
        {
            if (!OnlyNumber(_value)) throw new Exception("Value is not interge valid in LessThan->ValidationBase");

            if(int.Parse(_value) < Values) _listMessage.Add(BuildMessage(Message));
            return this;
        }

        public ReturnValidation IsValidBase()
        {
            return new ReturnValidation
            {
                CountErros = _listMessage.Count,
                GetMessageErros = _listMessage,
                IsValid = (_listMessage.Count == 0)
            };
        }

        private Validation BuildMessage(string Message)
        {
            var newMessage = Message.Replace(":field", _field);
            newMessage = newMessage.Replace(":Field", FirstCharToUpper(_field));
            newMessage = newMessage.Replace(":min", _min.ToString());
            newMessage = newMessage.Replace(":max", _max.ToString());

            if(!string.IsNullOrEmpty(_equal)) newMessage = newMessage.Replace(":equal", _equal);
            if(!string.IsNullOrEmpty(_value)) newMessage = newMessage.Replace(":length", _value);


            return new Validation { Message = newMessage, Field = _field };
        }

        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Insira uma palavra diferente de nula ou vazia");
            return input.Length > 1 ? char.ToUpper(input[0]) + input[1..] : input.ToUpper();
        }


        private bool OnlyNumber(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]+$");
        }

    }
}
