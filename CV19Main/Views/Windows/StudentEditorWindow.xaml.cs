using System.ComponentModel;
using System.Windows;

namespace CV19Main.Views.Windows
{

    public partial class StudentEditorWindow : Window
    {

        #region readonly StudentName : string - Имя студента

        ///<summary> Имя студента </summary>
        public static readonly DependencyProperty StudentNameProperty =
            DependencyProperty.Register(
                nameof(StudentName),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(null));



        ///<summary> Имя студента </summary>
        //[Category("")]
        [Description("Имя студента")]
        public string StudentName
        {
            get { return (string)GetValue(StudentNameProperty); }
            set { SetValue(StudentNameProperty, value); }
        }

        #endregion

        #region readonly SecondName : string - summary

        ///<summary> summary </summary>
        public static readonly DependencyProperty SecondNameProperty =
            DependencyProperty.Register(
                nameof(SecondName),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));



        ///<summary> summary </summary>
        //[Category("")]  
        [Description("summary")]
        public string SecondName
        {
            get { return (string)GetValue(SecondNameProperty); }
            set { SetValue(SecondNameProperty, value); }
        }

        #endregion

        #region readonly Birthaday : DateTime - День рождения студента 

        ///<summary> День рождения студента </summary>
        public static readonly DependencyProperty BirthadayProperty =
            DependencyProperty.Register(
                nameof(Birthaday),
                typeof(DateTime),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(DateTime)));



        ///<summary> День рождения студента </summary>
        //[Category("")]
        [Description("День рождения студента")]
        public DateTime Birthaday
        {
            get { return (DateTime)GetValue(BirthadayProperty); }
            set { SetValue(BirthadayProperty, value); }
        }

        #endregion

        #region readonly Rating : double - Успеваемость ученика

        ///<summary> Успеваемость ученика </summary>
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                nameof(Rating),
                typeof(double),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(double)));



        ///<summary> Успеваемость ученика </summary>
        //[Category("")]
        [Description("Успеваемость ученика")]
        public double Rating
        {
            get { return (double)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        #endregion

        public StudentEditorWindow()
        {
            InitializeComponent();
        }
    }
}
