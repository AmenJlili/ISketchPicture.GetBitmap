# SolidWorksBitmapHelper

A helper class that will help you get a bitmap object from a SolidWorks Sketch Picture object
Bitmap GetBitmapFromSketchPicture(SkechPicture sp)

# Example



  public void Main()
        {
            ModelDoc2 swModelDoc = (ModelDoc2)swApp.ActiveDoc;
            SelectionMgr swSelectionMgr = (SelectionMgr)swModelDoc.SelectionManager;
            swModelDoc.SelectByName(0,"Sketch Picture2"); 
            Feature swFeature = (Feature)swSelectionMgr.GetSelectedObject(1);
            SketchPicture sp = (SketchPicture)swFeature.GetSpecificFeature2();
            SolidWorksBitmapHelper.GetBitmapFromSketchPicture(sp).Save(@"c:\bitmap.bmp");;
            
        }
