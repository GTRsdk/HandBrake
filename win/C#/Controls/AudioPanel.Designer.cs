﻿/*  AudioPanel.Designer.cs $
 	
 	   This file is part of the HandBrake source code.
 	   Homepage: <http://handbrake.fr>.
 	   It may be used under the terms of the GNU General Public License. */

namespace Handbrake.Controls
{
    partial class AudioPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lv_audioList = new System.Windows.Forms.ListView();
            this.col_id = new System.Windows.Forms.ColumnHeader();
            this.col_Source = new System.Windows.Forms.ColumnHeader();
            this.col_codec = new System.Windows.Forms.ColumnHeader();
            this.col_mixdown = new System.Windows.Forms.ColumnHeader();
            this.col_samplerate = new System.Windows.Forms.ColumnHeader();
            this.col_bitrate = new System.Windows.Forms.ColumnHeader();
            this.col_drc = new System.Windows.Forms.ColumnHeader();
            this.audioMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.audioList_moveup = new System.Windows.Forms.ToolStripMenuItem();
            this.audioList_movedown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.audioList_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_RemoveAudioTrack = new System.Windows.Forms.Button();
            this.btn_addAudioTrack = new System.Windows.Forms.Button();
            this.lbl_drc = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_drc = new System.Windows.Forms.TrackBar();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.drp_audenc_1 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.drp_audmix_1 = new System.Windows.Forms.ComboBox();
            this.drp_track1Audio = new System.Windows.Forms.ComboBox();
            this.drp_audbit_1 = new System.Windows.Forms.ComboBox();
            this.drp_audsr_1 = new System.Windows.Forms.ComboBox();
            this.AudioTrackGroup = new System.Windows.Forms.GroupBox();
            this.AudioMenuRowHeightHack = new System.Windows.Forms.ImageList(this.components);
            this.audioMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_drc)).BeginInit();
            this.AudioTrackGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_audioList
            // 
            this.lv_audioList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_id,
            this.col_Source,
            this.col_codec,
            this.col_mixdown,
            this.col_samplerate,
            this.col_bitrate,
            this.col_drc});
            this.lv_audioList.ContextMenuStrip = this.audioMenu;
            this.lv_audioList.FullRowSelect = true;
            this.lv_audioList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_audioList.HideSelection = false;
            this.lv_audioList.LabelWrap = false;
            this.lv_audioList.Location = new System.Drawing.Point(16, 115);
            this.lv_audioList.MultiSelect = false;
            this.lv_audioList.Name = "lv_audioList";
            this.lv_audioList.Size = new System.Drawing.Size(689, 147);
            this.lv_audioList.TabIndex = 65;
            this.lv_audioList.UseCompatibleStateImageBehavior = false;
            this.lv_audioList.View = System.Windows.Forms.View.Details;
            this.lv_audioList.SelectedIndexChanged += new System.EventHandler(this.lv_audioList_SelectedIndexChanged);
            // 
            // col_id
            // 
            this.col_id.Text = "Track";
            this.col_id.Width = 47;
            // 
            // col_Source
            // 
            this.col_Source.Text = "Source";
            this.col_Source.Width = 170;
            // 
            // col_codec
            // 
            this.col_codec.Text = "Audio Codec";
            this.col_codec.Width = 88;
            // 
            // col_mixdown
            // 
            this.col_mixdown.Text = "Mixdown";
            this.col_mixdown.Width = 127;
            // 
            // col_samplerate
            // 
            this.col_samplerate.Text = "Samplerate (kHz)";
            this.col_samplerate.Width = 101;
            // 
            // col_bitrate
            // 
            this.col_bitrate.Text = "Bitrate (Kbps)";
            this.col_bitrate.Width = 95;
            // 
            // col_drc
            // 
            this.col_drc.Text = "DRC";
            // 
            // audioMenu
            // 
            this.audioMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioList_moveup,
            this.audioList_movedown,
            this.toolStripSeparator2,
            this.audioList_remove});
            this.audioMenu.Name = "audioMenu";
            this.audioMenu.Size = new System.Drawing.Size(142, 76);
            // 
            // audioList_moveup
            // 
            this.audioList_moveup.Name = "audioList_moveup";
            this.audioList_moveup.Size = new System.Drawing.Size(141, 22);
            this.audioList_moveup.Text = "Move Up";
            this.audioList_moveup.Click += new System.EventHandler(this.audioList_moveup_Click);
            // 
            // audioList_movedown
            // 
            this.audioList_movedown.Name = "audioList_movedown";
            this.audioList_movedown.Size = new System.Drawing.Size(141, 22);
            this.audioList_movedown.Text = "Move Down";
            this.audioList_movedown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.audioList_movedown.Click += new System.EventHandler(this.audioList_movedown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // audioList_remove
            // 
            this.audioList_remove.Name = "audioList_remove";
            this.audioList_remove.Size = new System.Drawing.Size(141, 22);
            this.audioList_remove.Text = "Remove";
            this.audioList_remove.Click += new System.EventHandler(this.audioList_remove_Click);
            // 
            // btn_RemoveAudioTrack
            // 
            this.btn_RemoveAudioTrack.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemoveAudioTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveAudioTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_RemoveAudioTrack.Location = new System.Drawing.Point(133, 268);
            this.btn_RemoveAudioTrack.Name = "btn_RemoveAudioTrack";
            this.btn_RemoveAudioTrack.Size = new System.Drawing.Size(111, 23);
            this.btn_RemoveAudioTrack.TabIndex = 64;
            this.btn_RemoveAudioTrack.Text = "Remove";
            this.btn_RemoveAudioTrack.UseVisualStyleBackColor = false;
            this.btn_RemoveAudioTrack.Click += new System.EventHandler(this.btn_RemoveAudioTrack_Click);
            // 
            // btn_addAudioTrack
            // 
            this.btn_addAudioTrack.BackColor = System.Drawing.Color.Transparent;
            this.btn_addAudioTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addAudioTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_addAudioTrack.Location = new System.Drawing.Point(16, 268);
            this.btn_addAudioTrack.Name = "btn_addAudioTrack";
            this.btn_addAudioTrack.Size = new System.Drawing.Size(111, 23);
            this.btn_addAudioTrack.TabIndex = 63;
            this.btn_addAudioTrack.Text = "Add Track";
            this.btn_addAudioTrack.UseVisualStyleBackColor = false;
            this.btn_addAudioTrack.Click += new System.EventHandler(this.btn_addAudioTrack_Click);
            // 
            // lbl_drc
            // 
            this.lbl_drc.AutoSize = true;
            this.lbl_drc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_drc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drc.Location = new System.Drawing.Point(658, 37);
            this.lbl_drc.Name = "lbl_drc";
            this.lbl_drc.Size = new System.Drawing.Size(14, 13);
            this.lbl_drc.TabIndex = 62;
            this.lbl_drc.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(607, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 12);
            this.label16.TabIndex = 61;
            this.label16.Text = "DRC";
            // 
            // tb_drc
            // 
            this.tb_drc.LargeChange = 0;
            this.tb_drc.Location = new System.Drawing.Point(598, 29);
            this.tb_drc.Margin = new System.Windows.Forms.Padding(0);
            this.tb_drc.Maximum = 31;
            this.tb_drc.Name = "tb_drc";
            this.tb_drc.Size = new System.Drawing.Size(57, 45);
            this.tb_drc.TabIndex = 60;
            this.tb_drc.TickFrequency = 10;
            this.tb_drc.Scroll += new System.EventHandler(this.tb_drc_Scroll);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(13, 13);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(92, 13);
            this.label68.TabIndex = 49;
            this.label68.Text = "Audio Tracks";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(463, 17);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(62, 12);
            this.label67.TabIndex = 57;
            this.label67.Text = "Samplerate";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(538, 17);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(39, 12);
            this.label66.TabIndex = 59;
            this.label66.Text = "Bitrate";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(234, 17);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(69, 12);
            this.label65.TabIndex = 53;
            this.label65.Text = "Audio Codec";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(368, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 12);
            this.label14.TabIndex = 55;
            this.label14.Text = "Mixdown";
            // 
            // drp_audenc_1
            // 
            this.drp_audenc_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_audenc_1.FormattingEnabled = true;
            this.drp_audenc_1.Items.AddRange(new object[] {
            "AAC (faac)",
            "MP3 (lame)",
            "Vorbis (vorbis)",
            "AC3 Passthru"});
            this.drp_audenc_1.Location = new System.Drawing.Point(215, 34);
            this.drp_audenc_1.Name = "drp_audenc_1";
            this.drp_audenc_1.Size = new System.Drawing.Size(111, 20);
            this.drp_audenc_1.TabIndex = 52;
            this.drp_audenc_1.Text = "AAC (faac)";
            this.drp_audenc_1.SelectedIndexChanged += new System.EventHandler(this.drp_audenc_1_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(86, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 12);
            this.label27.TabIndex = 51;
            this.label27.Text = "Source";
            // 
            // drp_audmix_1
            // 
            this.drp_audmix_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_audmix_1.FormattingEnabled = true;
            this.drp_audmix_1.Items.AddRange(new object[] {
            "Automatic",
            "Mono",
            "Stereo",
            "Dolby Surround",
            "Dolby Pro Logic II",
            "6 Channel Discrete"});
            this.drp_audmix_1.Location = new System.Drawing.Point(332, 34);
            this.drp_audmix_1.Name = "drp_audmix_1";
            this.drp_audmix_1.Size = new System.Drawing.Size(129, 20);
            this.drp_audmix_1.TabIndex = 54;
            this.drp_audmix_1.Text = "Automatic";
            this.drp_audmix_1.SelectedIndexChanged += new System.EventHandler(this.drp_audmix_1_SelectedIndexChanged);
            // 
            // drp_track1Audio
            // 
            this.drp_track1Audio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_track1Audio.FormattingEnabled = true;
            this.drp_track1Audio.Items.AddRange(new object[] {
            "Automatic"});
            this.drp_track1Audio.Location = new System.Drawing.Point(15, 35);
            this.drp_track1Audio.Name = "drp_track1Audio";
            this.drp_track1Audio.Size = new System.Drawing.Size(194, 20);
            this.drp_track1Audio.TabIndex = 50;
            this.drp_track1Audio.Text = "Automatic";
            this.drp_track1Audio.SelectedIndexChanged += new System.EventHandler(this.drp_track1Audio_SelectedIndexChanged);
            // 
            // drp_audbit_1
            // 
            this.drp_audbit_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_audbit_1.FormattingEnabled = true;
            this.drp_audbit_1.Items.AddRange(new object[] {
            "32",
            "40",
            "48",
            "56",
            "64",
            "80",
            "86",
            "112",
            "128",
            "160"});
            this.drp_audbit_1.Location = new System.Drawing.Point(525, 34);
            this.drp_audbit_1.Name = "drp_audbit_1";
            this.drp_audbit_1.Size = new System.Drawing.Size(70, 20);
            this.drp_audbit_1.TabIndex = 58;
            this.drp_audbit_1.Text = "160";
            this.drp_audbit_1.SelectedIndexChanged += new System.EventHandler(this.drp_audbit_1_SelectedIndexChanged);
            // 
            // drp_audsr_1
            // 
            this.drp_audsr_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_audsr_1.FormattingEnabled = true;
            this.drp_audsr_1.Items.AddRange(new object[] {
            "Auto",
            "48",
            "44.1",
            "32",
            "24",
            "22.05"});
            this.drp_audsr_1.Location = new System.Drawing.Point(467, 34);
            this.drp_audsr_1.Name = "drp_audsr_1";
            this.drp_audsr_1.Size = new System.Drawing.Size(55, 20);
            this.drp_audsr_1.TabIndex = 56;
            this.drp_audsr_1.Text = "Auto";
            this.drp_audsr_1.SelectedIndexChanged += new System.EventHandler(this.drp_audsr_1_SelectedIndexChanged);
            // 
            // AudioTrackGroup
            // 
            this.AudioTrackGroup.BackColor = System.Drawing.Color.Transparent;
            this.AudioTrackGroup.Controls.Add(this.drp_track1Audio);
            this.AudioTrackGroup.Controls.Add(this.drp_audsr_1);
            this.AudioTrackGroup.Controls.Add(this.drp_audbit_1);
            this.AudioTrackGroup.Controls.Add(this.drp_audmix_1);
            this.AudioTrackGroup.Controls.Add(this.lbl_drc);
            this.AudioTrackGroup.Controls.Add(this.label27);
            this.AudioTrackGroup.Controls.Add(this.label16);
            this.AudioTrackGroup.Controls.Add(this.drp_audenc_1);
            this.AudioTrackGroup.Controls.Add(this.tb_drc);
            this.AudioTrackGroup.Controls.Add(this.label14);
            this.AudioTrackGroup.Controls.Add(this.label65);
            this.AudioTrackGroup.Controls.Add(this.label67);
            this.AudioTrackGroup.Controls.Add(this.label66);
            this.AudioTrackGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioTrackGroup.ForeColor = System.Drawing.Color.Black;
            this.AudioTrackGroup.Location = new System.Drawing.Point(16, 32);
            this.AudioTrackGroup.Name = "AudioTrackGroup";
            this.AudioTrackGroup.Size = new System.Drawing.Size(689, 77);
            this.AudioTrackGroup.TabIndex = 66;
            this.AudioTrackGroup.TabStop = false;
            this.AudioTrackGroup.Text = "Selected Track: New Track";
            // 
            // AudioMenuRowHeightHack
            // 
            this.AudioMenuRowHeightHack.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.AudioMenuRowHeightHack.ImageSize = new System.Drawing.Size(1, 18);
            this.AudioMenuRowHeightHack.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AudioPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AudioTrackGroup);
            this.Controls.Add(this.lv_audioList);
            this.Controls.Add(this.btn_RemoveAudioTrack);
            this.Controls.Add(this.btn_addAudioTrack);
            this.Controls.Add(this.label68);
            this.Name = "AudioPanel";
            this.Size = new System.Drawing.Size(720, 310);
            this.audioMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_drc)).EndInit();
            this.AudioTrackGroup.ResumeLayout(false);
            this.AudioTrackGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lv_audioList;
        private System.Windows.Forms.ColumnHeader col_Source;
        private System.Windows.Forms.ColumnHeader col_codec;
        private System.Windows.Forms.ColumnHeader col_mixdown;
        private System.Windows.Forms.ColumnHeader col_samplerate;
        private System.Windows.Forms.ColumnHeader col_bitrate;
        private System.Windows.Forms.ColumnHeader col_drc;
        private System.Windows.Forms.Button btn_RemoveAudioTrack;
        private System.Windows.Forms.Button btn_addAudioTrack;
        internal System.Windows.Forms.Label lbl_drc;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TrackBar tb_drc;
        internal System.Windows.Forms.Label label68;
        internal System.Windows.Forms.Label label67;
        internal System.Windows.Forms.Label label66;
        internal System.Windows.Forms.Label label65;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox drp_audenc_1;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox drp_audmix_1;
        internal System.Windows.Forms.ComboBox drp_track1Audio;
        internal System.Windows.Forms.ComboBox drp_audbit_1;
        internal System.Windows.Forms.ComboBox drp_audsr_1;
        private System.Windows.Forms.ColumnHeader col_id;
        private System.Windows.Forms.GroupBox AudioTrackGroup;
        private System.Windows.Forms.ImageList AudioMenuRowHeightHack;
        private System.Windows.Forms.ContextMenuStrip audioMenu;
        private System.Windows.Forms.ToolStripMenuItem audioList_moveup;
        private System.Windows.Forms.ToolStripMenuItem audioList_movedown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem audioList_remove;
    }
}