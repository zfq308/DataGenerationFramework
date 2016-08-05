using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core
{
    #region PropertyValueGenerator

    public abstract class PropertyValueGenerator
    {
        private Random _rand;

        public PropertyValueGenerator(PropertyInfo property)
        {
            Property = property;
            _rand = new Random((int)DateTime.Now.Ticks);
        }

        public PropertyInfo Property { get; private set; }

        protected Random Random { get { return _rand; } }

        public void GenerateValue(Object obj)
        {
            Object value = GenerateValue();
            if (value != null)
            {
                Property.SetValue(obj, value);
            }
        }

        public PropertyValueGenerator WithFixValue(Object value)
        {
            return this;
        }

        protected virtual void Reset()
        {
            _rand = new Random((int)DateTime.Now.Ticks);
        }

        protected virtual Object GenerateValue()
        {
            return null;
        }
    }

    public class BooleanValueGenerator : PropertyValueGenerator
    {
        public BooleanValueGenerator(PropertyInfo pi)
            : base(pi) { }

        protected override object GenerateValue()
        {
            return Random.Next(0, 10) % 2 == 0;
        }
    }

    public class DecimalValueGenrator : PropertyValueGenerator
    {
        private decimal _min;
        private decimal _max;

        public DecimalValueGenrator(PropertyInfo property)
            : base(property)
        {
        }

        public DecimalValueGenrator UseMax(decimal value)
        {
            _max = value;
            return this;
        }

        public DecimalValueGenrator UseMin(decimal value)
        {
            _min = value;
            return this;
        }

        private bool _isUnique;
        public DecimalValueGenrator IsUnique(bool isUnique)
        {
            _isUnique = isUnique;
            return this;
        }

        protected override object GenerateValue()
        {
            return GetNextValue();
        }

        private readonly HashSet<decimal> _set = new HashSet<decimal>();
        private decimal GetNextValue()
        {
            var value = Random.Next(Convert.ToInt32(_min), Convert.ToInt32(_max));
            if (_isUnique)
            {
                if (_set.Contains(value))
                {
                    return GetNextValue();
                }

                _set.Add(value);
            }

            return value;
        }

        protected override void Reset()
        {
            base.Reset();

            _set.Clear();
        }
    }

    public class IntegerValueGenerator : PropertyValueGenerator
    {
        private int _min;
        private int _max;

        public IntegerValueGenerator(PropertyInfo property)
            : base(property)
        {
        }

        public IntegerValueGenerator UseMax(int value)
        {
            _max = value;
            return this;
        }

        public IntegerValueGenerator UseMin(int value)
        {
            _min = value;
            return this;
        }

        private bool _isUnique;
        public IntegerValueGenerator IsUnique(bool isUnique)
        {
            _isUnique = isUnique;
            return this;
        }

        protected override object GenerateValue()
        {
            return GetNextValue();
        }

        private readonly HashSet<int> _set = new HashSet<int>();
        private int GetNextValue()
        {
            var value = Random.Next(_min, _max);
            if (_isUnique)
            {
                if (_set.Contains(value))
                {
                    return GetNextValue();
                }

                _set.Add(value);
            }

            return value;
        }

        protected override void Reset()
        {
            base.Reset();

            _set.Clear();
        }

    }

    public class DateTimeValueGenerator : PropertyValueGenerator
    {
        public DateTimeValueGenerator(PropertyInfo property)
            : base(property) { }


        private DateTime _from;
        private DateTime _to;
        public DateTimeValueGenerator Range(DateTime from, DateTime to)
        {
            _to = to;
            _from = from;
            return this;
        }

        private bool _dateOnly;
        public DateTimeValueGenerator DateOnly(bool dateOnly)
        {
            _dateOnly = dateOnly;
            return this;
        }

        protected override object GenerateValue()
        {
            return GetNextValue();
        }

        private DateTime GetNextValue()
        {
            var span = TimeSpan.FromTicks(_to.Ticks - _from.Ticks);

            int dsf = Random.Next(1, (int)span.TotalDays);

            var rsult = _from.AddDays(dsf);

            if (_dateOnly)
                return rsult.Date;

            return rsult;
        }
    }

    public enum EnumStringType
    {
        RandomString = 0,
        RandomChineseString = 1,
        HumanData_Name = 100,
        HumanData_ChineseName = 101,
        HumanData_ChineseLastName = 102,
        HumanData_EmailAddress = 103,
        HumanData_ChineseNation = 104,
        HumanData_ChineseSchoolName = 105,
        HumanData_ChineseMobileNumber = 106,
        HumanData_ChineseRandomMobileNumber = 107,
        HumanData_ChinesePersonalSigner = 108,

        GEOData_Address = 200,
        GEOData_ChineseAddress = 201,
        GEOData_ChineseHomeTown = 202,

        Business_ChineseCommodity = 300,
        Business_ChineseCompanyName = 301,

        Language_ChineseTwoWord = 400,
        Language_ChineseFourWord = 401,
    }

    public class StringValueGenerator : PropertyValueGenerator
    {
        private int _min;
        private int _max;
        private EnumStringType _stringtype;
        private RepositoryGenerators gen = new RepositoryGenerators();

        public StringValueGenerator(PropertyInfo property)
            : base(property)
        {
        }

        public StringValueGenerator SetStringTypeEnum(EnumStringType stringtype, int minLength = 0, int maxLength = 0)
        {
            _stringtype = stringtype;
            if (stringtype == EnumStringType.RandomString || stringtype == EnumStringType.RandomChineseString)
            {
                if (minLength < 0 || maxLength <= 0 || minLength > maxLength)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _min = minLength;
                    _max = maxLength;
                    return this;
                }
            }
            return this;
        }

        protected override object GenerateValue()
        {
            switch (_stringtype)
            {
                case EnumStringType.RandomString:
                    String chars = "qwertzuiopasdfghjklyxcvbnmQWERTZUIOPSDFGHJKLYXCVBNM;:123<>0§456789ç%&/()=?`!èà£à-.¨,$äöé_:;";
                    return new string(Enumerable.Repeat(chars, Random.Next(_min, _max))
                       .Select(s => s[Random.Next(chars.Length)])
                       .ToArray());
                case EnumStringType.RandomChineseString:
                    String Chinesechars = CommonData.Chinesechars;
                    return new string(Enumerable.Repeat(Chinesechars, Random.Next(_min, _max))
                       .Select(s => s[Random.Next(Chinesechars.Length)])
                       .ToArray());
                case EnumStringType.HumanData_Name:
                    return gen.GetHumanData_Name(Gender.Male);
                case EnumStringType.HumanData_ChineseName:
                    return gen.GetHumanData_ChineseName();
                case EnumStringType.HumanData_ChineseLastName:
                    return gen.GetHumanData_ChineseLastName();
                case EnumStringType.HumanData_EmailAddress:
                    return gen.GetHumanData_EmailAddress();
                case EnumStringType.HumanData_ChineseNation:
                    return gen.GetHumanData_ChineseNation();
                case EnumStringType.HumanData_ChineseSchoolName:
                    return gen.GetHumanData_ChineseSchoolName();
                case EnumStringType.HumanData_ChineseMobileNumber:
                    return gen.GetHumanData_ChineseMobileNumber();
                case EnumStringType.HumanData_ChineseRandomMobileNumber:
                    return gen.GetHumanData_ChineseRandomMobileNumber();
                case EnumStringType.HumanData_ChinesePersonalSigner:
                    return gen.GetHumanData_ChinesePersonalSigner();
                case EnumStringType.GEOData_Address:
                    return gen.GetGEOData_Address();
                case EnumStringType.GEOData_ChineseAddress:
                    return gen.GetGEOData_ChineseAddress();
                case EnumStringType.GEOData_ChineseHomeTown:
                    return gen.GetGEOData_ChineseHomeTown();
                case EnumStringType.Business_ChineseCommodity:
                    return gen.GetBusiness_ChineseCommodity();
                case EnumStringType.Business_ChineseCompanyName:
                    return gen.GetBusiness_ChineseCompanyName();
                case EnumStringType.Language_ChineseTwoWord:
                    return gen.GetLanguage_ChineseTwoWord();
                case EnumStringType.Language_ChineseFourWord:
                    return gen.GetLanguage_ChineseFourWord();
                default:
                    return "";
            }
        }
    }

    #endregion

    public abstract class DataGenerator
    {
        protected DataGenerator(Type dataType)
        {
            DataType = dataType;
            Generators = new List<PropertyValueGenerator>(50);
        }

        public void GenerateValues(Object obj)
        {
            foreach (PropertyValueGenerator generator in Generators)
            {
                generator.GenerateValue(obj);
            }
        }

        protected ICollection<PropertyValueGenerator> Generators { get; private set; }

        public Type DataType { get; private set; }
    }

    public class DataGenerator<T> : DataGenerator
    {
        public DataGenerator()
            : base(typeof(T)) { }

        public BooleanValueGenerator Property(Expression<Func<T, bool>> expr)
        {
            var pu = ExpressionUtil.Property(expr);
            BooleanValueGenerator gen = Generators.OfType<BooleanValueGenerator>().SingleOrDefault(f => f.Property.Name == pu.Name);
            if (gen == null)
            {
                gen = new BooleanValueGenerator(pu);
                Generators.Add(gen);
            }

            return gen;
        }

        public DateTimeValueGenerator Property(Expression<Func<T, DateTime>> expr)
        {
            var pu = ExpressionUtil.Property(expr);
            DateTimeValueGenerator gen = Generators.OfType<DateTimeValueGenerator>().SingleOrDefault(f => f.Property.Name == pu.Name);
            if (gen == null)
            {
                gen = new DateTimeValueGenerator(pu);
                Generators.Add(gen);
            }

            return gen;
        }

        public IntegerValueGenerator Property(Expression<Func<T, int>> expr)
        {
            var pu = ExpressionUtil.Property(expr);
            IntegerValueGenerator gen = Generators.OfType<IntegerValueGenerator>().SingleOrDefault(f => f.Property.Name == pu.Name);
            if (gen == null)
            {
                gen = new IntegerValueGenerator(pu);
                Generators.Add(gen);
            }

            return gen;
        }

        public DecimalValueGenrator Property(Expression<Func<T, decimal>> expr)
        {
            var pu = ExpressionUtil.Property(expr);
            DecimalValueGenrator gen = Generators.OfType<DecimalValueGenrator>().SingleOrDefault(f => f.Property.Name == pu.Name);
            if (gen == null)
            {
                gen = new DecimalValueGenrator(pu);
                Generators.Add(gen);
            }

            return gen;
        }

        public StringValueGenerator Property(Expression<Func<T, String>> expr)
        {
            var pu = ExpressionUtil.Property(expr);
            StringValueGenerator gen = Generators.OfType<StringValueGenerator>().SingleOrDefault(f => f.Property.Name == pu.Name);
            if (gen == null)
            {
                gen = new StringValueGenerator(pu);
                Generators.Add(gen);
            }

            return gen;
        }

    }

    internal static class ExpressionUtil
    {
        /// <summary>
        /// Liefert aus der Expression eine MemberInfo Instanz, falls die Expression auf ein Property zeigt. Sonst Null.
        /// </summary>
        /// <param name="propertyExpression">Expression</param>
        /// <returns>MemberInfo oder Null</returns>
        public static MemberInfo MemberInfo(Expression propertyExpression)
        {
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }

        /// <summary>
        /// Liefert den Namen eines Properties inklusive des ganzen Objektgraphs. Bsp: Foo.Bar.MyProperty
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="expression">Expression</param>
        /// <returns>Namen eines Properties inklusive des ganzen Objektgraphs</returns>
        public static string NameWithPath<T>(Expression<Func<T, object>> expression)
        {
            var stack = new Stack<string>();

            MemberExpression me;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    break;

                default:
                    me = expression.Body as MemberExpression;
                    break;
            }

            while (me != null)
            {
                stack.Push(me.Member.Name);
                me = me.Expression as MemberExpression;
            }

            return string.Join(".", stack.ToArray());
        }

        /// <summary>
        /// Liefert den Namen eines Properties
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="expression">Expression</param>
        /// <returns>Propertyname</returns>
        public static string Name<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        /// <summary>
        /// Liefert den vollen Namen inklusive Namespace
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="expression">Expression</param>
        /// <returns>Propertyname</returns>
        public static string FullName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.DeclaringType.FullName + "." + body.Member.Name;
        }

        /// <summary>
        /// Liefert ein Porperty als PropertyInfo Instanz
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="selector">Expression</param>
        /// <returns>PropertyInfo</returns>
        public static PropertyInfo Property<T, TKey>(Expression<Func<T, TKey>> selector)
        {
            MemberExpression exp = null;

            //this line is necessary, because sometimes the expression comes as Convert(originalexpression)
            if (selector.Body is UnaryExpression)
            {
                UnaryExpression UnExp = (UnaryExpression)selector.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    exp = (MemberExpression)UnExp.Operand;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else if (selector.Body is MemberExpression)
            {
                exp = (MemberExpression)selector.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return (PropertyInfo)exp.Member;
        }
    }

    public static class ReflectionDataGenerate
    {
        static readonly Dictionary<Type, DataGenerator> _generators = new Dictionary<Type, DataGenerator>();

        public static DataGenerator<T1> ForClass<T1>()
        {
            Type t = typeof(T1);
            if (!_generators.ContainsKey(t))
            {
                _generators.Add(t, new DataGenerator<T1>());
            }
            return (DataGenerator<T1>)_generators[t];
        }

        public static IEnumerable<T> Items<T>(int count) where T : new()
        {
            List<T> items = new List<T>(count);

            Type type = typeof(T);
            if (_generators.ContainsKey(type))
            {
                DataGenerator generator = _generators[type];
                for (int i = 0; i < count; i++)
                {
                    T instance = (T)Activator.CreateInstance(type);

                    generator.GenerateValues(instance);

                    items.Add(instance);
                }
            }


            return items;
        }
    }

}
