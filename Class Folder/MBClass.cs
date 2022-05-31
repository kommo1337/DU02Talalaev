﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DU02Talalaev.Class_Folder
{
    class MBClass
    {
        public static void ErrorMb(string text)
        {       
            MessageBox.Show(text,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        public static void ErrorMb(Exception ex)
        { 
            MessageBox.Show(ex.Message,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void InfoMb(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static bool QuestionMB(string text)
        { 
            return MessageBoxResult.Yes == MessageBox.Show(text, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);    
        }
        public static void ExitMB()
        { 
            bool result = QuestionMB("Вы желаете выйти");
            if(result == true)
                App.Current.Shutdown();
        }
    }
}
