﻿using System;
using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.EventArgs;
using ResourceLib.Method;

namespace MongoGUICtl
{
    public partial class CtlMongodump : UserControl
    {
        private readonly MongodbDosCommand.StruMongoDump _mongodumpCommand = new MongodbDosCommand.StruMongoDump();
        public EventHandler<TextChangeEventArgs> CommandChanged;

        public CtlMongodump()
        {
            InitializeComponent();
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                lblCollectionName.Text =
                    GuiConfig.MStringResource.GetText(TextType.DosCommandTabBackupDcName);
                lblDBName.Text =
                    GuiConfig.MStringResource.GetText(TextType.DosCommandTabBackupDbName);
                lblHostAddr.Text =
                    GuiConfig.MStringResource.GetText(TextType.DosCommandTabBackupServer);
                lblPort.Text =
                    GuiConfig.MStringResource.GetText(TextType.DosCommandTabBackupPort);
                ctlFilePickerOutput.Title =
                    GuiConfig.MStringResource.GetText(TextType.DosCommandTabBackupPath);
            }
        }

        private void ctlMongodump_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += ctllogLvT_LoglvChanged;
            ctlFilePickerOutput.PathChanged += ctlFilePickerOutput_PathChanged;
        }

        protected virtual void OnCommandChange(TextChangeEventArgs e)
        {
            e.Raise(this, ref CommandChanged);
        }

        private void ctlFilePickerOutput_PathChanged(string filePath)
        {
            _mongodumpCommand.OutPutPath = filePath;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }

        private void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            _mongodumpCommand.LogLv = logLv;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }

        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            _mongodumpCommand.HostAddr = txtHostAddr.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            _mongodumpCommand.DbName = txtDBName.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            _mongodumpCommand.CollectionName = txtCollectionName.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            _mongodumpCommand.Port = (int) numPort.Value;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(_mongodumpCommand)));
        }
    }
}