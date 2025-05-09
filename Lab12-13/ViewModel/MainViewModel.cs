﻿using Lab12_13.Infractructure.Commands;
using Lab12_13.Model;
using Lab12_13.View;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;

namespace Lab12_13.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ClassMoto> Motos { get; set; }
        
        public MainViewModel()
        {
            Motos = new ObservableCollection<ClassMoto>();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      MotoView view = new MotoView(new ClassMoto());
                      if (view.ShowDialog() == true)
                      {
                          ClassMoto moto = view.Moto;
                          Motos.Add(moto);
                      }
                  }));
            }
        }
        private RelayCommand? saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(async (o) =>
                  {
                      SaveFileDialog sfd = new SaveFileDialog();
                      sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                      if (sfd.ShowDialog() == true)
                      {
                          using (StreamWriter writer=new StreamWriter(sfd.FileName,false))
                          {
                              foreach(ClassMoto i in Motos)
                              {
                                  await writer.WriteLineAsync(i.ToString());
                              }
                          }
                      }
                  }));
            }
        }
        private RelayCommand? openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(async (o) =>
                  {
                      OpenFileDialog ofd = new OpenFileDialog();
                      ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                      if (ofd.ShowDialog() == true)
                      {
                          using (StreamReader reader = new StreamReader(ofd.FileName))
                          {
                              string? line;
                              while((line=await reader.ReadLineAsync()) != null)
                              {
                                  string[] mas = line.Split(" ");
                                  ClassMoto moto = new ClassMoto
                                  (mas[0],
                                   (Color)ColorConverter.ConvertFromString(mas[1]),
                                   mas[2], 
                                   mas[3],
                                  int.Parse(mas[4]),
                                  int.Parse(mas[5]),
                                  decimal.Parse(mas[6]));
                                  Motos.Add(moto);
                              }
                          }
                      }
                  }));
            }
        }
    }
}
