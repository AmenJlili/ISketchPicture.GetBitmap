# GetBitmap() Extension Method

A helper method that returns bitmap object from a SolidWorks Sketch Picture object


# Example


         public void Main()
        {
            ModelDoc2 swModelDoc = (ModelDoc2)swApp.ActiveDoc;
            SelectionMgr swSelectionMgr = (SelectionMgr)swModelDoc.SelectionManager;
            swModelDoc.SelectByName(0,"Sketch Picture2"); 
            Feature swFeature = (Feature)swSelectionMgr.GetSelectedObject(1);
            SketchPicture sp = (SketchPicture)swFeature.GetSpecificFeature2();          
            string Error = string.Empty;
            Bitmap bitmap = SketchPicture.GetBitmap(out Error);
            if (bitmap != null)
            bitmap.Save(@"c:\bitmap.bmp");
        }


  
