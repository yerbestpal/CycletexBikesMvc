using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// BikeServices enum.
    /// Provides list of services that can be carried out on bikes.
    /// Renamed from 'Services' because Services is a built in class.
    /// </summary>
    public enum BikeServices
    {
        [Display(Name="Inner Tube Replacement")] InnerTubeReplacement,
        [Display(Name = "Hub Service")] HubService,
        [Display(Name = "Wheel Tuning")] WheelTuning,
        [Display(Name = "Wheel Assembly Font")] WheelAssemblyFont,
        [Display(Name = "Wheel Assembly Rear")] WheelAssemblyRear,
        [Display(Name = "Wheel Build")] WheelBuild,
        [Display(Name = "Freewheel Or Cassette")] FreewheelOrCassette,
        [Display(Name = "Spoke Replacement")] SpokeReplacement,
        [Display(Name = "Slime Service")] SlimeService,
        [Display(Name = "Standard Tubeless Setup")] StandardTubelessSetup,
        [Display(Name = "Premium Tubeless Setup")] PremiumTubelessSetup,
        [Display(Name = "Standard Tubeless Top-up")] StandardTubelessTopUp,
        [Display(Name = "Premium Tubeless Top-up")] PremiumTubelessTopUp,
        [Display(Name = "Gear Service")] GearService,
        [Display(Name = "Gear Shifter Replacement")] GearShifterReplacement,
        [Display(Name = "Chain Fitting")] ChainFitting,
        [Display(Name = "Drive Train Clean")] DrivetrainClean,
        [Display(Name = "Bottom Bracket Replacement or Service")] BottomBracketReplacementOrService,
        [Display(Name = "Front or Rear Mech")] FrontOrRearMech,
        [Display(Name = "Crank Replacement")] CrankReplacement,
        [Display(Name = "Jockey Wheel Replacement")] JockeyWheelReplacement,
        [Display(Name = "Mech Hanger Fit")] MechHangerFit,
        [Display(Name = "L or H Crank Arm Replacement")] L_Or_H_CrankArmReplacement,
        [Display(Name = "Brake Service Caliper and V Brakes")] BrakeServiceCaliperAnd_V_Brakes,
        [Display(Name = "Brake Level Fit")] BrakeLevelFit,
        [Display(Name = "Brake Fitting Hub and Frame Mount")] BrakeFittingHubAndFrameMount,
        [Display(Name = "Hydraulic Brake Bleed")] HydraulicBrakeBleed,
        [Display(Name = "Brake Pads and Blocks")] BrakePadsAndBlocks,
        [Display(Name = "Headset Replacement")] HeadsetReplacement,
        [Display(Name = "Handlebar Grip Replacement")] HandlebarGripsReplacement,
        [Display(Name = "Handlebar Re-Taping for Road Bike")] HandlebarRetapingForRoadBike,
        [Display(Name = "Stem Replacement")] StemReplacement,
        [Display(Name = "Comprehensive Fork Service")] ComprehensiveForkService
    }
}