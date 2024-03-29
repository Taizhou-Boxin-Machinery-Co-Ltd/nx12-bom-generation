' Mechatronics Concept Designer 12.0.0.27
' Journal created by Administrator on Tue Feb 27 21:30:55 2024 中国标准时间

'
Imports System
Imports NXOpen

Module NXJournal
Sub Main (ByVal args() As String) 

Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
Dim workPart As NXOpen.Part = theSession.Parts.Work

Dim displayPart As NXOpen.Part = theSession.Parts.Display

' ----------------------------------------------
'   菜单：应用模块(N)->钣金(L)
' ----------------------------------------------
Dim markId1 As NXOpen.Session.UndoMarkId = Nothing
markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Enter 钣金")

theSession.ApplicationSwitchImmediate("UG_APP_SBSM")

' ----------------------------------------------
'   菜单：插入(S)->突出块(B)...
' ----------------------------------------------
Dim markId2 As NXOpen.Session.UndoMarkId = Nothing
markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "开始")

Dim nullNXOpen_Features_Feature As NXOpen.Features.Feature = Nothing

Dim tabBuilder1 As NXOpen.Features.SheetMetal.TabBuilder = Nothing
tabBuilder1 = workPart.Features.SheetmetalManager.CreateTabFeatureBuilder(nullNXOpen_Features_Feature)

tabBuilder1.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

Dim expression1 As NXOpen.Expression = Nothing
expression1 = workPart.Preferences.PartSheetmetal.GetThickness()

Dim featureBendPropertiesListBuilder1 As NXOpen.Features.SheetMetal.FeatureBendPropertiesListBuilder = Nothing
featureBendPropertiesListBuilder1 = tabBuilder1.MultiBendPropertiesList

Dim multiBendBendPropertiesListBuilder1 As NXOpen.Features.SheetMetal.MultiBendBendPropertiesListBuilder = CType(featureBendPropertiesListBuilder1, NXOpen.Features.SheetMetal.MultiBendBendPropertiesListBuilder)

multiBendBendPropertiesListBuilder1.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

Dim multiBendBendPropertiesBuilder1 As NXOpen.Features.SheetMetal.MultiBendBendPropertiesBuilder = Nothing
multiBendBendPropertiesBuilder1 = multiBendBendPropertiesListBuilder1.CreateMultiBendBendProperties()

multiBendBendPropertiesBuilder1.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

Dim bendOptions1 As NXOpen.Features.SheetMetal.BendOptions = Nothing
bendOptions1 = multiBendBendPropertiesBuilder1.BendOptions

bendOptions1.ExtendBendRelief = True

Dim origin1 As NXOpen.Point3d = New NXOpen.Point3d(0.0, 0.0, 0.0)
Dim normal1 As NXOpen.Vector3d = New NXOpen.Vector3d(0.0, 0.0, 1.0)
Dim plane1 As NXOpen.Plane = Nothing
plane1 = workPart.Planes.CreatePlane(origin1, normal1, NXOpen.SmartObject.UpdateOption.WithinModeling)

multiBendBendPropertiesBuilder1.Plane = plane1

Dim unit1 As NXOpen.Unit = Nothing
unit1 = tabBuilder1.Thickness.Units

Dim expression2 As NXOpen.Expression = Nothing
expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

Dim expression3 As NXOpen.Expression = Nothing
expression3 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

multiBendBendPropertiesBuilder1.Plane = plane1

Dim expression4 As NXOpen.Expression = Nothing
expression4 = workPart.Preferences.PartSheetmetal.GetBendRadius()

Dim expression5 As NXOpen.Expression = Nothing
expression5 = workPart.Preferences.PartSheetmetal.GetNeutralFactor()

Dim expression6 As NXOpen.Expression = Nothing
expression6 = workPart.Preferences.PartSheetmetal.GetBendReliefDepth()

Dim expression7 As NXOpen.Expression = Nothing
expression7 = workPart.Preferences.PartSheetmetal.GetBendReliefWidth()

Dim nullNXOpen_Plane As NXOpen.Plane = Nothing

multiBendBendPropertiesBuilder1.Plane = nullNXOpen_Plane

Dim featureBendPropertiesBuilderList1 As NXOpen.Features.SheetMetal.FeatureBendPropertiesBuilderList = Nothing
featureBendPropertiesBuilderList1 = multiBendBendPropertiesListBuilder1.FeatureBendPropertiesList

Dim multiBendBendPropertiesBuilder2 As NXOpen.Features.SheetMetal.MultiBendBendPropertiesBuilder = Nothing
multiBendBendPropertiesBuilder2 = multiBendBendPropertiesListBuilder1.CreateMultiBendBendProperties()

multiBendBendPropertiesBuilder2.SetApplicationContext(NXOpen.Features.SheetMetal.ApplicationContext.NxSheetMetal)

Dim bendOptions2 As NXOpen.Features.SheetMetal.BendOptions = Nothing
bendOptions2 = multiBendBendPropertiesBuilder2.BendOptions

bendOptions2.ExtendBendRelief = True

Dim origin2 As NXOpen.Point3d = New NXOpen.Point3d(0.0, 0.0, 0.0)
Dim normal2 As NXOpen.Vector3d = New NXOpen.Vector3d(0.0, 0.0, 1.0)
Dim plane2 As NXOpen.Plane = Nothing
plane2 = workPart.Planes.CreatePlane(origin2, normal2, NXOpen.SmartObject.UpdateOption.WithinModeling)

multiBendBendPropertiesBuilder2.Plane = plane2

Dim expression8 As NXOpen.Expression = Nothing
expression8 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

Dim expression9 As NXOpen.Expression = Nothing
expression9 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

multiBendBendPropertiesBuilder2.Plane = plane2

Dim expression10 As NXOpen.Expression = Nothing
expression10 = workPart.Preferences.PartSheetmetal.GetBendRadius()

Dim expression11 As NXOpen.Expression = Nothing
expression11 = workPart.Preferences.PartSheetmetal.GetNeutralFactor()

Dim expression12 As NXOpen.Expression = Nothing
expression12 = workPart.Preferences.PartSheetmetal.GetBendReliefDepth()

Dim expression13 As NXOpen.Expression = Nothing
expression13 = workPart.Preferences.PartSheetmetal.GetBendReliefWidth()

multiBendBendPropertiesBuilder2.Plane = nullNXOpen_Plane

Dim expression14 As NXOpen.Expression = Nothing
expression14 = bendOptions2.BendReliefDepth

Dim expression15 As NXOpen.Expression = Nothing
expression15 = bendOptions2.BendReliefWidth

expression14.RightHandSide = "Sheet_Metal_Relief_Depth"

expression15.RightHandSide = "Sheet_Metal_Relief_Width"

Dim useglobalneutralfactor1 As Boolean = Nothing
useglobalneutralfactor1 = bendOptions2.UseGlobalNeutralFactor

bendOptions2.UseGlobalNeutralFactor = True

Dim useglobalbendradius1 As Boolean = Nothing
useglobalbendradius1 = bendOptions2.UseGlobalBendRadius

bendOptions2.UseGlobalBendRadius = True

bendOptions2.BendReliefType = NXOpen.Features.SheetMetal.BendOptions.BendReliefTypeOptions.Square

bendOptions2.CornerReliefType = NXOpen.Features.SheetMetal.BendOptions.CornerReliefTypeOptions.BendOnly

multiBendBendPropertiesBuilder2.Plane = nullNXOpen_Plane

featureBendPropertiesBuilderList1.Append(multiBendBendPropertiesBuilder2)

Dim expression16 As NXOpen.Expression = Nothing
expression16 = workPart.Preferences.PartSheetmetal.GetThickness()

Dim section1 As NXOpen.Section = Nothing
section1 = workPart.Sections.CreateSection(0.00095, 0.001, 0.050000000000000003)

theSession.SetUndoMarkName(markId2, "突出块 对话框")

Dim expression17 As NXOpen.Expression = Nothing
expression17 = bendOptions1.BendReliefDepth

Dim expression18 As NXOpen.Expression = Nothing
expression18 = bendOptions1.BendReliefWidth

expression17.RightHandSide = "Sheet_Metal_Relief_Depth"

expression18.RightHandSide = "Sheet_Metal_Relief_Width"

Dim useglobalneutralfactor2 As Boolean = Nothing
useglobalneutralfactor2 = bendOptions1.UseGlobalNeutralFactor

bendOptions1.UseGlobalNeutralFactor = True

Dim useglobalbendradius2 As Boolean = Nothing
useglobalbendradius2 = bendOptions1.UseGlobalBendRadius

bendOptions1.UseGlobalBendRadius = True

bendOptions1.BendReliefType = NXOpen.Features.SheetMetal.BendOptions.BendReliefTypeOptions.Square

bendOptions1.CornerReliefType = NXOpen.Features.SheetMetal.BendOptions.CornerReliefTypeOptions.BendOnly

section1.SetAllowedEntityTypes(NXOpen.Section.AllowTypes.OnlyCurves)

' ----------------------------------------------
'   菜单：工具(T)->操作记录(J)->停止录制(S)
' ----------------------------------------------

End Sub
End Module