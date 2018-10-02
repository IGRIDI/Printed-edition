using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{ 
    //класс для отловли исключительных ситуаций (наследник от Exception)
    class InvalidValueException : Exception
    {
        new public string Message { get; set; }

        public InvalidValueException(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Name:
                    Message = " !!ВНИМАНИЕ!! Поле имени не может быть изменено";
                    break;
                case FieldType.Cost:
                    Message = " !!ВНИМАНИЕ!! Недопустимое поле цены";
                    break;
                case FieldType.Index:
                    Message = " !!ВНИМАНИЕ!! Недопустимое поле индекса";
                    break;
                default:
                    Message = " !!ВНИМАНИЕ!! Неизвестное поле";
                    break;
            }
        }

    }
        enum FieldType
    {
        Name,
        Cost,
        Index
    }
}
