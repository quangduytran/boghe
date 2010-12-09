﻿/*
* Boghe IMS/RCS Client - Copyright (C) 2010 Mamadou Diop.
*
* Contact: Mamadou Diop <diopmamadou(at)doubango.org>
*	
* This file is part of Boghe Project (http://code.google.com/p/boghe)
*
* Boghe is free software: you can redistribute it and/or modify it under the terms of 
* the GNU General Public License as published by the Free Software Foundation, either version 3 
* of the License, or (at your option) any later version.
*	
* Boghe is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
* without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
* See the GNU General Public License for more details.
*	
* You should have received a copy of the GNU General Public License along 
* with this program; if not, write to the Free Software Foundation, Inc., 
* 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BogheControls;
using BogheApp.Services.Impl;
using BogheCore.Services;

namespace BogheApp.Screens
{
    /// <summary>
    /// Interaction logic for ScreenOptions.xaml
    /// </summary>
    public partial class ScreenOptions : BaseScreen
    {
        private readonly IConfigurationService configurationService;

        public ScreenOptions()
        {
            InitializeComponent();

            this.configurationService = Win32ServiceManager.SharedManager.ConfigurationService;

            this.radioButtonContactsRemote.Checked += delegate(object sender, RoutedEventArgs e) { this.groupBoxXCAP.IsEnabled = true; };
            this.radioButtonContactsRemote.Unchecked += delegate(object sender, RoutedEventArgs e) { this.groupBoxXCAP.IsEnabled = false; };

            this.InitializeCodecs();

            this.LoadConfiguration();
        }        

        private void SaveConfiguration()
        {
            if (!this.UpdateIdentity())
                return;

            if (!this.UpdateNetwork())
                return;

            if (!this.UpdateContacts())
                return;

            if (!this.UpdatePresence())
                return;

            if (!this.UpdateCodecs())
                return;
        }

        private void LoadConfiguration()
        {
            this.LoadIdentity();
            this.LoadNetwork();
            this.LoadContacts();
            this.LoadPresence();
            this.LoadCodecs();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.SaveConfiguration();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.LoadConfiguration();
        }
    }
}
