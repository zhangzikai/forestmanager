namespace DataEdit
{
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    internal class CreateShapeFile
    {
        private IFeatureClass pFeatureClass = null;
        private IFieldsEdit pFields = null;
        private IWorkspace pWorkspace = null;

        public CreateShapeFile(IWorkspace workspace)
        {
            if (workspace != null)
            {
                this.pWorkspace = workspace;
                this.pFields = new FieldsClass();
            }
        }

        public bool AddFeatures(List<IPolyline> arrPolyline, List<string> name)
        {
            try
            {
                IWorkspaceEdit pWorkspace = this.pWorkspace as IWorkspaceEdit;
                pWorkspace.StartEditing(true);
                pWorkspace.StartEditOperation();
                IFeatureBuffer buffer = this.pFeatureClass.CreateFeatureBuffer();
                IFeatureCursor cursor = this.pFeatureClass.Insert(true);
                for (int i = 0; i < arrPolyline.Count; i++)
                {
                    int index = buffer.Fields.FindField("name");
                    buffer.set_Value(index, name[i]);
                    buffer.Shape = arrPolyline[i];
                    cursor.InsertFeature(buffer);
                    cursor.Flush();
                    int num3 = this.pFeatureClass.FeatureCount(null);
                }
                pWorkspace.StopEditOperation();
                pWorkspace.StopEditing(true);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public void AddField(string fieldname, object fieldtype)
        {
            IFieldEdit field = new FieldClass();
            field.Name_2 = fieldname;
            if (fieldtype is string)
            {
                field.Type_2 = esriFieldType.esriFieldTypeString;
            }
            else if (fieldtype is int)
            {
                field.Type_2 = esriFieldType.esriFieldTypeInteger;
            }
            else if (fieldtype is double)
            {
                field.Type_2 = esriFieldType.esriFieldTypeDouble;
            }
            this.pFields.AddField(field);
        }

        public void AddShapeField(string shapefieldname, IGeometry geoType)
        {
            IFieldEdit field = new FieldClass();
            field.Name_2 = shapefieldname;
            field.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef def = new GeometryDefClass();
            IGeometryDefEdit edit2 = def as IGeometryDefEdit;
            ISpatialReferenceFactory2 factory = new SpatialReferenceEnvironmentClass();
            IGeographicCoordinateSystem system = factory.CreateGeographicCoordinateSystem(0x1202);
            edit2.SpatialReference_2 = system;
            edit2.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            field.GeometryDef_2 = def;
            this.pFields.AddField(field);
        }

        public IFeatureClass CreateFeatureClass(string featureClassName)
        {
            this.pFeatureClass = this.CreateFeatureClass((IWorkspace2) this.pWorkspace, null, featureClassName, this.pFields, null, null, "");
            return this.pFeatureClass;
        }

        public IFeatureClass CreateFeatureClass(IWorkspace2 workspace, IFeatureDataset featureDataset, string featureClassName, IFields fields, UID CLSID, UID CLSEXT, string strConfigKeyword)
        {
            IFeatureClass class2;
            if (featureClassName == "")
            {
                return null;
            }
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) workspace;
            while (workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassName))
            {
                featureClassName = featureClassName + "副本";
            }
            if (CLSID == null)
            {
                CLSID = new UIDClass();
                CLSID.Value = "esriGeoDatabase.Feature";
            }
            IObjectClassDescription description = new FeatureClassDescriptionClass();
            if (fields == null)
            {
                fields = description.RequiredFields;
                IFieldsEdit edit = (IFieldsEdit) fields;
                IField field = new FieldClass();
                IFieldEdit edit2 = (IFieldEdit) field;
                edit2.Name_2 = "SampleField";
                edit2.Type_2 = esriFieldType.esriFieldTypeString;
                edit2.IsNullable_2 = true;
                edit2.AliasName_2 = "Sample Field Column";
                edit2.DefaultValue_2 = "test";
                edit2.Editable_2 = true;
                edit2.Length_2 = 100;
                edit.AddField(field);
                fields = edit;
            }
            string shapeFieldName = "";
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    shapeFieldName = fields.get_Field(i).Name;
                }
            }
            IFieldChecker checker = new FieldCheckerClass();
            IEnumFieldError error = null;
            IFields fixedFields = null;
            checker.ValidateWorkspace = (IWorkspace) workspace;
            checker.Validate(fields, out error, out fixedFields);
            if (featureDataset == null)
            {
                class2 = workspace2.CreateFeatureClass(featureClassName, fixedFields, CLSID, CLSEXT, esriFeatureType.esriFTSimple, shapeFieldName, strConfigKeyword);
            }
            else
            {
                class2 = featureDataset.CreateFeatureClass(featureClassName, fixedFields, CLSID, CLSEXT, esriFeatureType.esriFTSimple, shapeFieldName, strConfigKeyword);
            }
            return class2;
        }
    }
}

