﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureSettingsViewModel.cs" company="HandBrake Project (http://handbrake.fr)">
//   This file is part of the HandBrake source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   The Picture Settings View Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HandBrakeWPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Drawing;

    using Caliburn.Micro;

    using HandBrake.ApplicationServices.Model;
    using HandBrake.ApplicationServices.Parsing;
    using HandBrake.ApplicationServices.Services.Interfaces;
    using HandBrake.Interop.Model.Encoding;

    using HandBrakeWPF.ViewModels.Interfaces;

    /// <summary>
    /// The Picture Settings View Model
    /// </summary>
    [Export(typeof(IPictureSettingsViewModel))]
    public class PictureSettingsViewModel : ViewModelBase, IPictureSettingsViewModel
    {
        /*
         * TODO:
         * - We are not handling cropping correctly within the UI.
         * - The Height is not correctly set when using no Anamorphic
         * - Maintain Aspect ratio needs corrected.
         * 
         */
        #region Constants and Fields

        /// <summary>
        /// The display size.
        /// </summary>
        private string displaySize;

        /// <summary>
        ///  Backing field for for height control enabled
        /// </summary>
        private bool heightControlEnabled = true;

        /// <summary>
        ///  Backing field for show custom anamorphic controls
        /// </summary>
        private bool showCustomAnamorphicControls;

        /// <summary>
        /// The source aspect ratio.
        /// </summary>
        private double sourceAspectRatio;

        /// <summary>
        /// The source info.
        /// </summary>
        private string sourceInfo;

        /// <summary>
        /// Source Par Values
        /// </summary>
        private Size sourceParValues;

        /// <summary>
        /// Source Resolution
        /// </summary>
        private Size sourceResolution;

        /// <summary>
        /// Backing field for width control enabled.
        /// </summary>
        private bool widthControlEnabled = true;

        /// <summary>
        /// Backing field for the show modulus field
        /// </summary>
        private bool showModulus;

        /// <summary>
        /// Backing field for showing display size.
        /// </summary>
        private bool showDisplaySize;

        /// <summary>
        /// Backing field for max height
        /// </summary>
        private int maxHeight;

        /// <summary>
        /// Backing field for max width
        /// </summary>
        private int maxWidth;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HandBrakeWPF.ViewModels.PictureSettingsViewModel"/> class.
        /// </summary>
        /// <param name="windowManager">
        /// The window manager.
        /// </param>
        /// <param name="userSettingService">
        /// The user Setting Service.
        /// </param>
        public PictureSettingsViewModel(IWindowManager windowManager, IUserSettingService userSettingService)
        {
            this.Task = new EncodeTask();
            this.SelectedModulus = 16;
            this.MaintainAspectRatio = true;

            // Default the Max Width / Height to 1080p format
            this.MaxHeight = 1080;
            this.MaxWidth = 1920;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets AnamorphicModes.
        /// </summary>
        public IEnumerable<Anamorphic> AnamorphicModes
        {
            get
            {
                return new List<Anamorphic> { Anamorphic.None, Anamorphic.Strict, Anamorphic.Loose, Anamorphic.Custom };
            }
        }

        /// <summary>
        /// Gets or sets CropBottom.
        /// </summary>
        public int CropBottom
        {
            get
            {
                return this.Task.Cropping.Bottom;
            }

            set
            {
                this.Task.Cropping.Bottom = this.CorrectForModulus(this.Task.Cropping.Bottom, value);
                this.NotifyOfPropertyChange(() => this.CropBottom);
                this.SetDisplaySize();
            }
        }

        /// <summary>
        /// Gets or sets CropLeft.
        /// </summary>
        public int CropLeft
        {
            get
            {
                return this.Task.Cropping.Left;
            }

            set
            {
                this.Task.Cropping.Left = this.CorrectForModulus(this.Task.Cropping.Left, value);
                this.NotifyOfPropertyChange(() => this.CropLeft);
                this.SetDisplaySize();
            }
        }

        /// <summary>
        /// Gets or sets CropRight.
        /// </summary>
        public int CropRight
        {
            get
            {
                return this.Task.Cropping.Right;
            }

            set
            {
                this.Task.Cropping.Right = this.CorrectForModulus(this.Task.Cropping.Right, value);
                this.NotifyOfPropertyChange(() => this.CropRight);
                this.SetDisplaySize();
            }
        }

        /// <summary>
        /// Gets or sets CropTop.
        /// </summary>
        public int CropTop
        {
            get
            {
                return this.Task.Cropping.Top;
            }

            set
            {
                this.Task.Cropping.Top = this.CorrectForModulus(this.Task.Cropping.Top, value);
                this.NotifyOfPropertyChange(() => this.CropTop);
                this.SetDisplaySize();
            }
        }

        /// <summary>
        /// Gets or sets DisplaySize.
        /// </summary>
        public string DisplaySize
        {
            get
            {
                return this.displaySize;
            }

            set
            {
                this.displaySize = value;
                this.NotifyOfPropertyChange(() => this.DisplaySize);
            }
        }

        /// <summary>
        /// Gets or sets DisplayWidth.
        /// </summary>
        public int DisplayWidth
        {
            get
            {
                return this.Task.DisplayWidth.HasValue
                           ? int.Parse(Math.Round(this.Task.DisplayWidth.Value, 0).ToString())
                           : 0;
            }

            set
            {
                this.Task.DisplayWidth = value;
                this.CustomAnamorphicAdjust();
                this.NotifyOfPropertyChange(() => this.DisplayWidth);
            }
        }

        /// <summary>
        /// Gets or sets Height.
        /// </summary>
        public int Height
        {
            get
            {
                return this.Task.Height.HasValue ? this.Task.Height.Value : 0;
            }

            set
            {
                this.Task.Height = value;
                this.HeightAdjust();
                this.NotifyOfPropertyChange(() => this.Height);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether HeightControlEnabled.
        /// </summary>
        public bool HeightControlEnabled
        {
            get
            {
                return this.heightControlEnabled;
            }

            set
            {
                this.heightControlEnabled = value;
                this.NotifyOfPropertyChange(() => this.HeightControlEnabled);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsCustomCrop.
        /// </summary>
        public bool IsCustomCrop
        {
            get
            {
                return this.Task.HasCropping;
            }

            set
            {
                this.Task.HasCropping = value;
                this.NotifyOfPropertyChange(() => this.IsCustomCrop);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether MaintainAspectRatio.
        /// </summary>
        public bool MaintainAspectRatio
        {
            get
            {
                return this.Task.KeepDisplayAspect;
            }

            set
            {
                this.Task.KeepDisplayAspect = value;
                this.WidthAdjust();
                this.NotifyOfPropertyChange(() => this.MaintainAspectRatio);
            }
        }

        /// <summary>
        /// Gets ModulusValues.
        /// </summary>
        public IEnumerable<int> ModulusValues
        {
            get
            {
                return new List<int> { 16, 8, 4, 2 };
            }
        }

        /// <summary>
        /// Gets or sets ParHeight.
        /// </summary>
        public int ParHeight
        {
            get
            {
                return this.Task.PixelAspectY;
            }

            set
            {
                this.Task.PixelAspectY = value;
                this.CustomAnamorphicAdjust();
                this.NotifyOfPropertyChange(() => this.ParHeight);
            }
        }

        /// <summary>
        /// Gets or sets ParWidth.
        /// </summary>
        public int ParWidth
        {
            get
            {
                return this.Task.PixelAspectX;
            }

            set
            {
                this.Task.PixelAspectX = value;
                this.CustomAnamorphicAdjust();
                this.NotifyOfPropertyChange(() => this.ParWidth);
            }
        }

        /// <summary>
        /// Gets or sets SelectedAnamorphicMode.
        /// </summary>
        public Anamorphic SelectedAnamorphicMode
        {
            get
            {
                return this.Task.Anamorphic;
            }

            set
            {
                this.Task.Anamorphic = value;
                this.AnamorphicAdjust();
                this.NotifyOfPropertyChange(() => this.SelectedAnamorphicMode);
            }
        }

        /// <summary>
        /// Gets or sets SelectedModulus.
        /// </summary>
        public int? SelectedModulus
        {
            get
            {
                return this.Task.Modulus;
            }

            set
            {
                this.Task.Modulus = value;
                this.ModulusAdjust();
                this.NotifyOfPropertyChange(() => this.SelectedModulus);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowCustomAnamorphicControls.
        /// </summary>
        public bool ShowCustomAnamorphicControls
        {
            get
            {
                return this.showCustomAnamorphicControls;
            }

            set
            {
                this.showCustomAnamorphicControls = value;
                this.NotifyOfPropertyChange(() => this.ShowCustomAnamorphicControls);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowModulus.
        /// </summary>
        public bool ShowModulus
        {
            get
            {
                return this.showModulus;
            }
            set
            {
                this.showModulus = value;
                this.NotifyOfPropertyChange(() => this.ShowModulus);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowDisplaySize.
        /// </summary>
        public bool ShowDisplaySize
        {
            get
            {
                return this.showDisplaySize;
            }
            set
            {
                this.showDisplaySize = value;
                this.NotifyOfPropertyChange(() => this.ShowDisplaySize);
            }
        }

        /// <summary>
        /// Gets or sets SourceInfo.
        /// </summary>
        public string SourceInfo
        {
            get
            {
                return this.sourceInfo;
            }

            set
            {
                this.sourceInfo = value;
                this.NotifyOfPropertyChange(() => this.SourceInfo);
            }
        }

        /// <summary>
        /// Gets or sets Task.
        /// </summary>
        public EncodeTask Task { get; set; }

        /// <summary>
        /// Gets or sets Width.
        /// </summary>
        public int Width
        {
            get
            {
                return this.Task.Width.HasValue ? this.Task.Width.Value : 0;
            }

            set
            {
                this.Task.Width = value;
                this.WidthAdjust();
                this.NotifyOfPropertyChange(() => this.Width);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether WidthControlEnabled.
        /// </summary>
        public bool WidthControlEnabled
        {
            get
            {
                return this.widthControlEnabled;
            }

            set
            {
                this.widthControlEnabled = value;
                this.NotifyOfPropertyChange(() => this.WidthControlEnabled);
            }
        }

        /// <summary>
        /// Gets or sets MaxHeight.
        /// </summary>
        public int MaxHeight
        {
            get
            {
                return this.maxHeight;
            }
            set
            {
                this.maxHeight = value;
                this.NotifyOfPropertyChange(() => this.MaxHeight);
            }
        }

        /// <summary>
        /// Gets or sets MinHeight.
        /// </summary>
        public int MaxWidth
        {
            get
            {
                return this.maxWidth;
            }
            set
            {
                this.maxWidth = value;
                this.NotifyOfPropertyChange(() => this.MaxWidth);
            }
        }

        /// <summary>
        /// Gets SourceAspect.
        /// </summary>
        private Size SourceAspect
        {
            get
            {
                // display aspect = (width * par_width) / (height * par_height)
                return new Size(
                    (this.sourceParValues.Width * this.sourceResolution.Width),
                    (this.sourceParValues.Height * this.sourceResolution.Height));
            }
        }

        #endregion

        #region Implemented Interfaces

        #region ITabInterface

        /// <summary>
        /// Setup this tab for the specified preset.
        /// </summary>
        /// <param name="preset">
        /// The preset.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        public void SetPreset(Preset preset, EncodeTask task)
        {
            this.Task = task;

            // TODO: These all need to be handled correctly.
            this.SelectedAnamorphicMode = preset.Task.Anamorphic;

            // Set the limits on the UI Controls.
            this.MaxWidth = sourceResolution.Width;
            this.MaxHeight = sourceResolution.Height;
            this.Task.MaxWidth = preset.Task.MaxWidth;
            this.Task.MaxHeight = preset.Task.MaxHeight;

            if (preset.Task.MaxWidth.HasValue)
            {
                if (this.Width > preset.Task.MaxWidth)
                {
                    this.Width = preset.Task.MaxWidth.Value;
                }
                else
                {
                    this.Width = preset.Task.Width ?? this.getRes((sourceResolution.Width - this.CropLeft - this.CropRight), preset.Task.MaxWidth.Value);
                }
            }
            else
            {
                this.Width = preset.Task.Width ?? (sourceResolution.Width - this.CropLeft - this.CropRight);
            }

            if (preset.Task.MaxHeight.HasValue)
            {
                if (this.Height > preset.Task.MaxHeight)
                {
                    this.Height = preset.Task.MaxHeight.Value;
                }
                else
                {
                    this.Height = preset.Task.Height ?? this.getRes((sourceResolution.Height - this.CropTop - this.CropBottom), preset.Task.MaxHeight.Value);
                }
            }

            // Anamorphic
            if (preset.Task.Anamorphic == Anamorphic.Custom)
            {
                this.DisplayWidth = preset.Task.DisplayWidth != null ? int.Parse(preset.Task.DisplayWidth.ToString()) : 0;
                this.ParWidth = preset.Task.PixelAspectX;
                this.ParHeight = preset.Task.PixelAspectY;
            }

            // Default this to On.
            this.MaintainAspectRatio = preset.Task.Anamorphic == Anamorphic.None || preset.Task.KeepDisplayAspect;

            if (preset.Task.Modulus.HasValue)
            {
                this.SelectedModulus = preset.Task.Modulus;
            }

            if (preset.Task.HasCropping)
            {
                this.IsCustomCrop = true;
                this.CropLeft = preset.Task.Cropping.Left;
                this.CropRight = preset.Task.Cropping.Right;
                this.CropTop = preset.Task.Cropping.Top;
                this.CropBottom = preset.Task.Cropping.Bottom;
            }
            else
            {
                this.IsCustomCrop = false;
            }

            this.NotifyOfPropertyChange(() => this.Task);
        }

        /// <summary>
        /// Update all the UI controls based on the encode task passed in.
        /// </summary>
        /// <param name="task">
        /// The task.
        /// </param>
        public void UpdateTask(EncodeTask task)
        {
            this.Task = task;
            this.NotifyOfPropertyChange(() => this.Width);
            this.NotifyOfPropertyChange(() => this.Height);
            this.NotifyOfPropertyChange(() => this.SelectedAnamorphicMode);
            this.NotifyOfPropertyChange(() => this.SelectedModulus);
            this.NotifyOfPropertyChange(() => this.DisplayWidth);
            this.NotifyOfPropertyChange(() => this.ParHeight);
            this.NotifyOfPropertyChange(() => this.ParWidth);
        }

        /// <summary>
        /// Setup this window for a new source
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="preset">
        /// The preset.
        /// </param>
        /// <param name="task">
        /// The task.
        /// </param>
        public void SetSource(Title title, Preset preset, EncodeTask task)
        {
            this.Task = task;

            if (title != null)
            {
                // Set cached info
                this.sourceAspectRatio = title.AspectRatio;
                this.sourceParValues = title.ParVal;
                this.sourceResolution = title.Resolution;

                // Set the Max Width / Height available to the user controls
                if (sourceResolution.Width < this.MaxWidth)
                {
                    this.MaxWidth = sourceResolution.Width;
                }
                else if (sourceResolution.Width > this.MaxWidth)
                {
                    this.MaxWidth = preset.Task.MaxWidth ?? sourceResolution.Width;
                }

                if (sourceResolution.Height < this.MaxHeight)
                {
                    this.MaxHeight = sourceResolution.Height;
                }
                else if (sourceResolution.Height > this.MaxHeight)
                {
                    this.MaxHeight = preset.Task.MaxHeight ?? sourceResolution.Height;
                }

                // Set Screen Controls
                this.SourceInfo = string.Format(
                    "{0}x{1}, Aspect Ratio: {2:0.00}",
                    title.Resolution.Width,
                    title.Resolution.Height,
                    title.AspectRatio);

                if (!preset.Task.HasCropping)
                {
                    this.CropTop = title.AutoCropDimensions.Top;
                    this.CropBottom = title.AutoCropDimensions.Bottom;
                    this.CropLeft = title.AutoCropDimensions.Left;
                    this.CropRight = title.AutoCropDimensions.Right;
                    this.IsCustomCrop = false;
                }
                else
                {
                    this.CropLeft = preset.Task.Cropping.Left;
                    this.CropRight = preset.Task.Cropping.Right;
                    this.CropTop = preset.Task.Cropping.Top;
                    this.CropBottom = preset.Task.Cropping.Bottom;
                    this.IsCustomCrop = true;
                }

                // TODO handle preset max width / height
                this.Width = title.Resolution.Width;
                this.Height = title.Resolution.Height;
                this.MaintainAspectRatio = true;

                if (this.SelectedAnamorphicMode == Anamorphic.Custom)
                {
                    AnamorphicAdjust(); // Refresh the values
                }
            }

            this.NotifyOfPropertyChange(() => this.Task);
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Adjust other values after the user has altered the anamorphic.
        /// </summary>
        private void AnamorphicAdjust()
        {
            this.DisplaySize = this.sourceResolution.IsEmpty
                                   ? "No Title Selected"
                                   : string.Format(
                                       "{0}x{1}",
                                       this.CalculateAnamorphicSizes().Width,
                                       this.CalculateAnamorphicSizes().Height);

            this.ShowDisplaySize = true;
            switch (this.SelectedAnamorphicMode)
            {
                case Anamorphic.None:
                    this.WidthControlEnabled = true;
                    this.HeightControlEnabled = true;
                    this.ShowCustomAnamorphicControls = false;
                    this.ShowModulus = true;
                    this.ShowDisplaySize = false;
                    this.SelectedModulus = 16; // Reset
                    this.Width = this.sourceResolution.Width;
                    this.SetDisplaySize();
                    break;
                case Anamorphic.Strict:
                    this.WidthControlEnabled = false;
                    this.HeightControlEnabled = false;
                    this.ShowCustomAnamorphicControls = false;
                    this.ShowModulus = false;
                    this.SelectedModulus = 16; // Reset

                    this.Width = 0;
                    this.Height = 0;
                    this.NotifyOfPropertyChange(() => this.Width);
                    this.NotifyOfPropertyChange(() => this.Height);
                    this.SetDisplaySize();
                    break;

                case Anamorphic.Loose:
                    this.WidthControlEnabled = true;
                    this.HeightControlEnabled = false;
                    this.ShowCustomAnamorphicControls = false;
                    this.ShowModulus = true;

                    this.Width = this.sourceResolution.Width;
                    this.Height = 0;
                    this.NotifyOfPropertyChange(() => this.Width);
                    this.NotifyOfPropertyChange(() => this.Height);
                    this.SetDisplaySize();
                    break;

                case Anamorphic.Custom:
                    this.WidthControlEnabled = true;
                    this.HeightControlEnabled = true;
                    this.ShowCustomAnamorphicControls = true;
                    this.MaintainAspectRatio = true;
                    this.ShowModulus = true;

                    this.Width = this.sourceResolution.Width;
                    this.NotifyOfPropertyChange(() => this.Width);
                    this.NotifyOfPropertyChange(() => this.Height);

                    this.DisplayWidth = this.CalculateAnamorphicSizes().Width;
                    this.ParWidth = this.sourceParValues.Width;
                    this.ParHeight = this.sourceParValues.Height;
                    this.NotifyOfPropertyChange(() => this.ParHeight);
                    this.NotifyOfPropertyChange(() => this.ParWidth);
                    this.NotifyOfPropertyChange(() => this.DisplayWidth);

                    this.SetDisplaySize();
                    break;
            }
        }

        /// <summary>
        /// Calculate the Anamorphic Resolution for the selected title.
        /// </summary>
        /// <returns>
        /// A Size With Width/Height for this title.
        /// </returns>
        private Size CalculateAnamorphicSizes()
        {
            if (this.sourceResolution.IsEmpty)
            {
                return new Size(0, 0);
            }

            /* Set up some variables to make the math easier to follow. */
            int croppedWidth = this.sourceResolution.Width - this.CropLeft - this.CropRight;
            int croppedHeight = this.sourceResolution.Height - this.CropTop - this.CropBottom;
            double storageAspect = (double)croppedWidth / croppedHeight;

            /* Figure out what width the source would display at. */
            double sourceDisplayWidth = (double)croppedWidth * this.sourceParValues.Width / this.sourceParValues.Height;

            /*
                 3 different ways of deciding output dimensions:
                  - 1: Strict anamorphic, preserve source dimensions
                  - 2: Loose anamorphic, round to mod16 and preserve storage aspect ratio
                  - 3: Power user anamorphic, specify everything
              */
            double calcWidth, calcHeight;
            switch (this.SelectedAnamorphicMode)
            {
                default:
                case Anamorphic.Strict:

                    /* Strict anamorphic */
                    double dispWidth = ((double)croppedWidth * this.sourceParValues.Width / this.sourceParValues.Height);
                    dispWidth = Math.Round(dispWidth, 0);
                    Size output = new Size((int)dispWidth, croppedHeight);
                    return output;

                case Anamorphic.Loose:

                    /* "Loose" anamorphic.
                        - Uses mod16-compliant dimensions,
                        - Allows users to set the width
                    */
                    calcWidth = this.GetModulusValue(this.Width); /* Time to get picture width that divide cleanly.*/
                    calcHeight = (calcWidth / storageAspect) + 0.5;
                    calcHeight = this.GetModulusValue(calcHeight); /* Time to get picture height that divide cleanly.*/

                    /* The film AR is the source's display width / cropped source height.
                       The output display width is the output height * film AR.
                       The output PAR is the output display width / output storage width. */
                    double pixelAspectWidth = calcHeight * sourceDisplayWidth / croppedHeight;
                    double pixelAspectHeight = calcWidth;

                    double disWidthLoose = (calcWidth * pixelAspectWidth / pixelAspectHeight);
                    if (double.IsNaN(disWidthLoose))
                    {
                        disWidthLoose = 0;
                    }

                    return new Size((int)disWidthLoose, (int)calcHeight);

                case Anamorphic.Custom:

                    // Get the User Interface Values
                    double UIdisplayWidth;
                    double.TryParse(this.DisplayWidth.ToString(), out UIdisplayWidth);

                    /* Anamorphic 3: Power User Jamboree - Set everything based on specified values */
                    calcHeight = this.GetModulusValue(this.Height);

                    if (this.MaintainAspectRatio)
                    {
                        return new Size((int)Math.Truncate(UIdisplayWidth), (int)calcHeight);
                    }

                    return new Size((int)Math.Truncate(UIdisplayWidth), (int)calcHeight);
            }
        }

        /// <summary>
        /// Correct the new value so that the result of the modulus of that value is 0
        /// </summary>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        /// <returns>
        /// The Value corrected so that for a given modulus the result is 0
        /// </returns>
        private int CorrectForModulus(int oldValue, int newValue)
        {
            int remainder = newValue % 2;
            if (remainder == 0)
            {
                return newValue;
            }

            return newValue > oldValue ? newValue + remainder : newValue - remainder;
        }

        /// <summary>
        /// Adjust other values after the user has altered one of the custom anamorphic settings
        /// </summary>
        private void CustomAnamorphicAdjust()
        {
            this.SetDisplaySize();
        }

        /// <summary>
        /// For a given value, correct so that it matches the users currently selected modulus value
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// Value corrected so that value % selected modulus == 0
        /// </returns>
        private double GetModulusValue(double value)
        {
            if (this.SelectedModulus == null)
            {
                return 0;
            }

            double remainder = value % this.SelectedModulus.Value;

            if (remainder == 0)
            {
                return value;
            }

            return remainder >= ((double)this.SelectedModulus.Value / 2)
                       ? value + (this.SelectedModulus.Value - remainder)
                       : value - remainder;
        }

        /// <summary>
        /// Adjust other values after the user has altered the height
        /// </summary>
        private void HeightAdjust()
        {
            if (this.Height > this.sourceResolution.Height)
            {
                this.Task.Height = this.sourceResolution.Height;
                this.NotifyOfPropertyChange(() => this.Task.Height);
            }

            switch (this.SelectedAnamorphicMode)
            {
                case Anamorphic.None:
                    if (this.MaintainAspectRatio)
                    {
                        double crop_width = this.sourceResolution.Width - this.CropLeft - this.CropRight;
                        double crop_height = this.sourceResolution.Height - this.CropTop - this.CropBottom;

                        double new_width = ((double)this.Height * this.sourceResolution.Height * this.SourceAspect.Width *
                                            crop_width) /
                                           (this.sourceResolution.Width * this.SourceAspect.Height * crop_height);

                        this.Task.Width = (int)Math.Round(this.GetModulusValue(new_width), 0);
                        this.NotifyOfPropertyChange(() => this.Task.Width);
                    }

                    break;
                case Anamorphic.Custom:
                    this.SetDisplaySize();
                    break;
            }
        }

        /// <summary>
        /// Adjust other values after the user has altered the modulus
        /// </summary>
        private void ModulusAdjust()
        {
            this.WidthAdjust();
        }

        /// <summary>
        /// Set the display size text
        /// </summary>
        private void SetDisplaySize()
        {
            this.DisplaySize = this.sourceResolution.IsEmpty
                                   ? "No Title Selected"
                                   : string.Format(
                                       "{0}x{1}",
                                       this.CalculateAnamorphicSizes().Width,
                                       this.CalculateAnamorphicSizes().Height);
        }

        /// <summary>
        /// Adjust other values after the user has altered the width
        /// </summary>
        private void WidthAdjust()
        {
            if (this.Width > this.sourceResolution.Width)
            {
                this.Task.Width = this.sourceResolution.Width;
                this.NotifyOfPropertyChange(() => this.Task.Width);
            }

            switch (this.SelectedAnamorphicMode)
            {
                case Anamorphic.None:
                    if (this.MaintainAspectRatio)
                    {
                        double crop_width = this.sourceResolution.Width - this.CropLeft - this.CropRight;
                        double crop_height = this.sourceResolution.Height - this.CropTop - this.CropBottom;

                        if (this.SourceAspect.Width == 0 && this.SourceAspect.Height == 0)
                        {
                            break;
                        }

                        double newHeight = ((double)this.Width * this.sourceResolution.Width * this.SourceAspect.Height *
                                            crop_height) /
                                           (this.sourceResolution.Height * this.SourceAspect.Width * crop_width);

                        this.Task.Height = (int)Math.Round(this.GetModulusValue(newHeight), 0);
                        this.NotifyOfPropertyChange(() => this.Height);
                    }
                    this.SetDisplaySize();
                    break;
                case Anamorphic.Strict:
                    this.Task.Width = 0;
                    this.Task.Height = 0;

                    this.NotifyOfPropertyChange(() => this.Width);
                    this.NotifyOfPropertyChange(() => this.Height);
                    this.SetDisplaySize();
                    break;
                case Anamorphic.Loose:
                    this.Task.Height = 0;
                    this.NotifyOfPropertyChange(() => this.Width);
                    this.NotifyOfPropertyChange(() => this.Height);
                    this.SetDisplaySize();
                    break;
                case Anamorphic.Custom:
                    this.SetDisplaySize();
                    break;
            }
        }

        /// <summary>
        /// Quick function to get the max resolution value
        ///  </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        /// <returns>
        /// An Int
        /// </returns>
        private int getRes(int value, int max)
        {
            if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }

            return 0;
        }

        #endregion
    }
}