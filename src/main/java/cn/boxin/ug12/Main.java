package cn.boxin.ug12;

import nxopen.*;
import nxopen.blockstyler.BlockDialog;
import nxopen.features.BlockFeatureBuilder;
import nxopen.features.BlockFeatureBuilder_impl;
import nxopen.features.sheetmetal.*;
import nxopen.menubar.MenuButtonEvent;

import java.rmi.RemoteException;

import static nxopen.menubar.MenuBarManager.*;

public class Main implements
        InitializeMenuApplication,
        EnterMenuApplication,
        ExitMenuApplication,
        ActionCallback
{

    public static int testStatus = 0;

    public static Session theSession;
    public static ListingWindow lw;
    public static UI theUI;

    static Main main;

    // Used to tell us if we've already registered our callbacks
    public static int registered = 0;
    static int isDisposeCalled;
    public Main() {
        try {
            theSession = (Session) SessionFactory.get("Session");
            lw = theSession.listingWindow();
            theUI = (UI) SessionFactory.get("UI");
            initializeCallbacks();
        } catch (Exception e) {
            errorMessage(e);
        }
    }

    public static void main(String[] args) {
        try {
            theSession = (Session) SessionFactory.get("Session");
            if (args[0].equals("3")) {
                Part prt = theSession.parts().work();
                int i = theSession.setUndoMark(Session.MarkVisibility.VISIBLE, "开始");
                TabBuilder tabBuilder = prt.features().sheetmetalManager().createTabFeatureBuilder(null);
                Expression expression = prt.preferences().partSheetmetal().getThickness();
                FeatureBendPropertiesListBuilder featureBendPropertiesListBuilder = tabBuilder.multiBendPropertiesList();
                MultiBendBendPropertiesListBuilder multiBendBendPropertiesListBuilder = (MultiBendBendPropertiesListBuilder) featureBendPropertiesListBuilder;
                multiBendBendPropertiesListBuilder.setApplicationContext(ApplicationContext.NX_SHEET_METAL);
                MultiBendBendPropertiesBuilder multiBendBendPropertiesBuilder = multiBendBendPropertiesListBuilder.createMultiBendBendProperties();
                multiBendBendPropertiesBuilder.setApplicationContext(ApplicationContext.NX_SHEET_METAL);
                BendOptions bendOptions = multiBendBendPropertiesBuilder.bendOptions();
                bendOptions.setExtendBendRelief(true);
                Point3d origin = new Point3d(0, 0, 0);
                Vector3d normal = new Vector3d(0.0, 0.0, 1.0);
                Plane planel = prt.planes().createPlane(origin, normal, SmartObject.UpdateOption.WITHIN_MODELING);
                multiBendBendPropertiesBuilder.setPlane(planel);
                Unit unit = expression.units();
                Expression expression2 = prt.expressions().createSystemExpressionWithUnits("0", unit);
                Expression expression3 = prt.expressions().createSystemExpressionWithUnits("0", unit);
                multiBendBendPropertiesBuilder.setPlane(planel);

            }
        } catch (Exception e) {
            errorMessage(e);
        }

//        try {
//            main = new Main();
//
//        } catch (Exception ignored) {
//        }
    }

    private void initializeCallbacks() {
        try {
            if (registered == 0) {
                int app = theUI.menuBarManager().registerApplication("Boxin_Bom_Generation", this, this, this, true, true, true);
                theUI.menuBarManager().addMenuAction("Generation", this);
                registered = 1;
            }
        } catch (Exception e) {
            errorMessage(e);
        }
    }

    public static int getUnloadOption() {
        return BaseSession.LibraryUnloadOption.AT_TERMINATION;
    }

    @Override
    public CallbackStatus actionCallback(MenuButtonEvent event) throws NXException, RemoteException {
        nxopen.menubar.MenuBarManager.CallbackStatus status = nxopen.menubar.MenuBarManager.CallbackStatus.CONTINUE;
        try
        {
            // First we need to determine which button's action we need to perform
            if( event.activeButton().buttonName().equals("SAMPLE_JAVA_APP_BUTTON1") )
            {
                status = printButtonId(event);
            }
            else
            {
                lw.open();
                lw.writeLine(" ");
                lw.writeLine("Inside Unknown JAVA actionCallback");
                lw.writeLine("'"+event.activeButton().buttonName()+"'");
                lw.writeLine(" ");
            }
        }
        catch(Exception e)
        {
            errorMessage(e);
        }
        return status;
    }

    public CallbackStatus printButtonId(MenuButtonEvent event) {
        CallbackStatus status = CallbackStatus.CONTINUE;
        try {
            lw.open();
            lw.writeLine(" ");
            lw.writeLine("Inside printButtonId Callback:");
            lw.writeLine("    Button Id: " + event.activeButton().buttonId());
            lw.writeLine(" ");
        } catch (Exception e) {
            errorMessage(e);
        }
        return status;
    }

    public CallbackStatus testCallbackReturns(MenuButtonEvent event) {
        CallbackStatus status = CallbackStatus.CONTINUE;
        try
        {
            lw.open();
            lw.writeLine(" ");
            lw.writeLine("Inside testCallbackReturns Callback:");

            if( testStatus == 0 )
            {
                status = CallbackStatus.CONTINUE;
                lw.writeLine("    Returning: nxopen.menubar.MenuBarManager.CallbackStatus.CONTINUE");
            }
            else if( testStatus == 1 )
            {
                status = CallbackStatus.CANCEL;
                lw.writeLine("    Returning: nxopen.menubar.MenuBarManager.CallbackStatus.CANCEL");
            }
            else if( testStatus == 2 )
            {
                status = CallbackStatus.OVERRIDE_STANDARD;
                lw.writeLine("    Returning: nxopen.menubar.MenuBarManager.CallbackStatus.OVERRIDE_STANDARD");
            }
            else if( testStatus == 3 )
            {
                status = CallbackStatus.WARNING;
                lw.writeLine("    Returning: nxopen.menubar.MenuBarManager.CallbackStatus.WARNING");
            }
            else if( testStatus == 4 )
            {
                status = CallbackStatus.ERROR;
                lw.writeLine("    Returning: nxopen.menubar.MenuBarManager.CallbackStatus.ERROR");
            }
            lw.writeLine(" ");
            testStatus++;
            if( testStatus > 4 )
            {
                testStatus = 0;
            }

        }
        catch(Exception e)
        {
            errorMessage(e);
        }
        return status;
    }

    public CallbackStatus printApplicationId(MenuButtonEvent event) {
        CallbackStatus status = CallbackStatus.CONTINUE;
        try
        {
            lw.open();
            lw.writeLine(" ");
            lw.writeLine("Inside printApplicationIdCB Callback:");
            lw.writeLine("    Application Id: " + event.applicationId());
            lw.writeLine(" ");
        }
        catch(Exception e) {
            errorMessage(e);
        }
        return status;
    }

    @Override
    public int enterMenuApplication() throws NXException, RemoteException {
        try {
            lw.open();
            lw.writeLine(" ");
            lw.writeLine("Inside Boxin Enter Proc");
            lw.writeLine(" ");
        } catch (Exception e) {
            errorMessage(e);
        }
        return 0;
    }

    @Override
    public int exitMenuApplication() throws NXException, RemoteException {
        try {
            lw.open();
            lw.writeLine(" ");
            lw.writeLine("Inside Boxin Exit Proc");
            lw.writeLine(" ");
        } catch (Exception e) {
            errorMessage(e);
        }
        return 0;
    }

    @Override
    public int initializeMenuApplication() throws NXException, RemoteException {
        try {
            lw.open();;
            lw.writeLine(" ");
            lw.writeLine("Inside Boxin Init Proc");
            lw.writeLine(" ");
        } catch (Exception e) {
            errorMessage(e);
        }
        return 0;
    }

    public static void errorMessage(Exception e) {
        System.err.println("Error Message");
        System.err.println(e.getMessage());
    }
}
