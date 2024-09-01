// Name: Channels-Mixer
// Submenu: Custom
// Author: Meridiano
// Title: Channels-Mixer
// Version: 1.1
// Desc: Mixes RGBA channels for selected pixels
// Keywords: Channels-Mixer
// URL: https://github.com/Meridiano
// Help: https://github.com/Meridiano
#region UICode
ListBoxControl tRed = 1; // Target Red|Custom|Source Red|Source Green|Source Blue|Source Alpha
CheckboxControl tRedInvert = false; // {!tRed} Inversion
IntSliderControl tRedCustom = 100; // [0,255,5] {tRed} Target Red - Custom
ListBoxControl tGreen = 2; // Target Green|Custom|Source Red|Source Green|Source Blue|Source Alpha
CheckboxControl tGreenInvert = false; // {!tGreen} Inversion
IntSliderControl tGreenCustom = 100; // [0,255,5] {tGreen} Target Green - Custom
ListBoxControl tBlue = 3; // Target Blue|Custom|Source Red|Source Green|Source Blue|Source Alpha
CheckboxControl tBlueInvert = false; // {!tBlue} Inversion
IntSliderControl tBlueCustom = 100; // [0,255,5] {tBlue} Target Blue - Custom
ListBoxControl tAlpha = 4; // Target Alpha|Custom|Source Red|Source Green|Source Blue|Source Alpha
CheckboxControl tAlphaInvert = false; // {!tAlpha} Inversion
IntSliderControl tAlphaCustom = 100; // [0,255,5] {tAlpha} Target Alpha - Custom
#endregion
// begin render
void Render(Surface Destination, Surface Source, Rectangle Canvas)
{
    // define variables
    ColorBgra SourcePixel = new ColorBgra();
    ColorBgra TargetPixel = new ColorBgra();
    int TargetR = 0;
    int TargetG = 0;
    int TargetB = 0;
    int TargetA = 0;
    // process canvas
    for (int X = Canvas.Left; X < Canvas.Right; X++)
    {
        if (IsCancelRequested) return;
        for (int Y = Canvas.Top; Y < Canvas.Bottom; Y++)
        {
            {
                SourcePixel = Source[X,Y];
                // process red
                if (tRed == 0) { TargetR = tRedCustom; }
                else {
                    if (tRed == 1) { TargetR = SourcePixel.R; }
                    else if (tRed == 2) { TargetR = SourcePixel.G; }
                    else if (tRed == 3) { TargetR = SourcePixel.B; }
                    else if (tRed == 4) { TargetR = SourcePixel.A; }
                    if (tRedInvert) { TargetR = 255 - TargetR; }
                }
                // process green
                if (tGreen == 0) { TargetG = tGreenCustom; }
				else {
					if (tGreen == 1) { TargetG = SourcePixel.R; }
					else if (tGreen == 2) { TargetG = SourcePixel.G; }
					else if (tGreen == 3) { TargetG = SourcePixel.B; }
					else if (tGreen == 4) { TargetG = SourcePixel.A; }
					if (tGreenInvert) { TargetG = 255 - TargetG; }
				}
                // process blue
                if (tBlue == 0) { TargetB = tBlueCustom; }
				else {
					if (tBlue == 1) { TargetB = SourcePixel.R; }
					else if (tBlue == 2) { TargetB = SourcePixel.G; }
					else if (tBlue == 3) { TargetB = SourcePixel.B; }
					else if (tBlue == 4) { TargetB = SourcePixel.A; }
					if (tBlueInvert) { TargetB = 255 - TargetB; }
				}
                // process alpha
                if (tAlpha == 0) { TargetA = tAlphaCustom; }
				else {
					if (tAlpha == 1) { TargetA = SourcePixel.R; }
					else if (tAlpha == 2) { TargetA = SourcePixel.G; }
					else if (tAlpha == 3) { TargetA = SourcePixel.B; }
					else if (tAlpha == 4) { TargetA = SourcePixel.A; }
					if (tAlphaInvert) { TargetA = 255 - TargetA; }
				}
                // set target
                TargetPixel.R = (byte)TargetR;
                TargetPixel.G = (byte)TargetG;
                TargetPixel.B = (byte)TargetB;
                TargetPixel.A = (byte)TargetA;
                // push target
                Destination[X,Y] = TargetPixel;
            }
        }
    }
}