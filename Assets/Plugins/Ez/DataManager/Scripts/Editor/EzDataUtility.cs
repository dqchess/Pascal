// Copyright (c) 2016 Ez Entertainment SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Ez.DataManager
{
    public class EzDataUtility
    {
        private static string pathDataManager;
        public static string PathDataManager { get { if(string.IsNullOrEmpty(pathDataManager)) pathDataManager = FileHelper.GetRelativeFolderPath("Ez") + "/DataManager/"; return pathDataManager; } }

        const string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
        const string NumberChars = "0123456789";

        const string sDataManagerHeader =
@"// Copyright (c) 2016 Ez Entertainment SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

// This partial class is Auto-Generated by the EzDataUtility

using UnityEngine;
using System.Collections.Generic;

namespace Ez.DataManager
{
    public partial class EzDataManager
    {
#pragma warning disable 0649

";
        #region Headers
        #region Float
        const string floatSetterHeader =
@"
        public static bool SetFloatByName(string varName, float value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string floatGetterHeader =
@"
        public static bool GetFloatByName(string varName, out float value)
        {
            value = 0f;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Int
        const string intSetterHeader =
@"
        public static bool SetIntByName(string varName, int value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";

        const string intGetterHeader =
@"
        public static bool GetIntByName(string varName, out int value)
        {
            value = 0;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Bool
        const string boolSetterHeader =
@"
        public static bool SetBoolByName(string varName, bool value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string boolGetterHeader =
@"
        public static bool GetBoolByName(string varName, out bool value)
        {
            value = false;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region GameObject
        const string gameObjectSetterHeader =
@"
        public static bool SetGameObjectByName(string varName, GameObject value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string gameObjectGetterHeader =
@"
        public static bool GetGameObjectByName(string varName, out GameObject value)
        {
            value = null;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region String
        const string stringSetterHeader =
@"
        public static bool SetStringByName(string varName, string value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string stringGetterHeader =
@"
        public static bool GetStringByName(string varName, out string value)
        {
            value = string.Empty;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Vector2
        const string vector2SetterHeader =
@"
        public static bool SetVector2ByName(string varName, Vector2 value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string vector2GetterHeader =
@"
        public static bool GetVector2ByName(string varName, out Vector2 value)
        {
            value = Vector2.zero;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Vector3
        const string vector3SetterHeader =
@"
        public static bool SetVector3ByName(string varName, Vector3 value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string vector3GetterHeader =
@"
        public static bool GetVector3ByName(string varName, out Vector3 value)
        {
            value = Vector3.zero;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Color
        const string colorSetterHeader =
@"
        public static bool SetColorByName(string varName, Color value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string colorGetterHeader =
@"
        public static bool GetColorByName(string varName, out Color value)
        {
            value = Color.black;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Rect
        const string rectSetterHeader =
@"
        public static bool SetRectByName(string varName, Rect value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string rectGetterHeader =
@"
        public static bool GetRectByName(string varName, out Rect value)
        {
            value = new Rect();
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Material
        const string materialSetterHeader =
@"
        public static bool SetMaterialByName(string varName, Material value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string materialGetterHeader =
@"
        public static bool GetMaterialByName(string varName, out Material value)
        {
            value = null;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Texture
        const string textureSetterHeader =
@"
        public static bool SetTextureByName(string varName, Texture value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string textureGetterHeader =
@"
        public static bool GetTextureByName(string varName, out Texture value)
        {
            value = null;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Quaternion
        const string quaternionSetterHeader =
@"
        public static bool SetQuaternionByName(string varName, Quaternion value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string quaternionGetterHeader =
@"
        public static bool GetQuaternionByName(string varName, out Quaternion value)
        {
            value = Quaternion.identity;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Object
        const string objectSetterHeader =
@"
        public static bool SetObjectByName(string varName, Object value)
        {
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        const string objectGetterHeader =
@"
        public static bool GetObjectByName(string varName, out Object value)
        {
            value = null;
            if(string.IsNullOrEmpty(varName)) return false;
            switch(varName)
            {
";
        #endregion
        #region Arrays
        const string arraySetterHeader =
@"
        public static bool SetArrayByName(string arrayName, System.Array array)
        {
            if(string.IsNullOrEmpty(arrayName)) return false;
            try
            {
                switch(arrayName)
                {
";
        const string arrayGetterHeader =
@"
        public static bool GetArrayByName(string arrayName, out System.Array array)
        {
            array = null;
            if(string.IsNullOrEmpty(arrayName)) return false;
            switch(arrayName)
            {
";
        #endregion
        #endregion
        #region Footers
        const string functionFooter =
@"                default:
                    return false;
            }
        }
";
        const string arraySetterFooter =
@"                    default:
                        return false;
                }
            }
            catch(System.Exception)
            {
                return false;
            } 
        }
";
        #endregion

        const string sDataManagerFooter =
@"
#pragma warning restore 0649
    }
}";
        public static void GenerateEzDataManagerScript(Dictionary<string, List<EzDataManagerEditor.Variable>> data)
        {
            var sb = new StringBuilder();
            sb.Append(sDataManagerHeader);

            var floatGetterBuilder = new StringBuilder(floatGetterHeader);
            var floatSetterBuilder = new StringBuilder(floatSetterHeader);

            var intGetterBuilder = new StringBuilder(intGetterHeader);
            var intSetterBuilder = new StringBuilder(intSetterHeader);

            var boolGetterBuilder = new StringBuilder(boolGetterHeader);
            var boolSetterBuilder = new StringBuilder(boolSetterHeader);

            var gameObjectGetterBuilder = new StringBuilder(gameObjectGetterHeader);
            var gameObjectSetterBuilder = new StringBuilder(gameObjectSetterHeader);

            var stringGetterBuilder = new StringBuilder(stringGetterHeader);
            var stringSetterBuilder = new StringBuilder(stringSetterHeader);

            var vector2GetterBuilder = new StringBuilder(vector2GetterHeader);
            var vector2SetterBuilder = new StringBuilder(vector2SetterHeader);

            var vector3GetterBuilder = new StringBuilder(vector3GetterHeader);
            var vector3SetterBuilder = new StringBuilder(vector3SetterHeader);

            var colorGetterBuilder = new StringBuilder(colorGetterHeader);
            var colorSetterBuilder = new StringBuilder(colorSetterHeader);

            var rectGetterBuilder = new StringBuilder(rectGetterHeader);
            var rectSetterBuilder = new StringBuilder(rectSetterHeader);

            var materialGetterBuilder = new StringBuilder(materialGetterHeader);
            var materialSetterBuilder = new StringBuilder(materialSetterHeader);

            var textureGetterBuilder = new StringBuilder(textureGetterHeader);
            var textureSetterBuilder = new StringBuilder(textureSetterHeader);

            var quaternionGetterBuilder = new StringBuilder(quaternionGetterHeader);
            var quaternionSetterBuilder = new StringBuilder(quaternionSetterHeader);

            var objectGetterBuilder = new StringBuilder(objectGetterHeader);
            var objectSetterBuilder = new StringBuilder(objectSetterHeader);

            var arrayGetterBuilder = new StringBuilder(arrayGetterHeader);
            var arraySetterBuilder = new StringBuilder(arraySetterHeader);

            if(data != null && data.Keys.Count > 0)
            {
                int categoryId = 0;
                int numberOfItems = 0;
                foreach(var key in data.Keys)
                {
                    sb.Append(GetStartCategory(key, categoryId));
                    numberOfItems = 0;
                    if(data[key] != null && data[key].Count > 0)
                    {
                        foreach(var v in data[key])
                        {
                            sb.Append(GetVariableLine(v.variableType, v.typeName, v.name));
                            numberOfItems++;
                            // setup the functions for PlayMaker actions
                            if(v.variableType.Equals("variable"))
                            {
                                switch(v.typeName)
                                {
                                    case "int":
                                        UpdateVariableGetterAndSetter(intGetterBuilder, intSetterBuilder, v.name);
                                        break;
                                    case "float":
                                        UpdateVariableGetterAndSetter(floatGetterBuilder, floatSetterBuilder, v.name);
                                        break;
                                    case "bool":
                                        UpdateVariableGetterAndSetter(boolGetterBuilder, boolSetterBuilder, v.name);
                                        break;
                                    case "GameObject":
                                        UpdateVariableGetterAndSetter(gameObjectGetterBuilder, gameObjectSetterBuilder, v.name);
                                        break;
                                    case "string":
                                        UpdateVariableGetterAndSetter(stringGetterBuilder, stringSetterBuilder, v.name);
                                        break;
                                    case "Vector2":
                                        UpdateVariableGetterAndSetter(vector2GetterBuilder, vector2SetterBuilder, v.name);
                                        break;
                                    case "Vector3":
                                        UpdateVariableGetterAndSetter(vector3GetterBuilder, vector3SetterBuilder, v.name);
                                        break;
                                    case "Color":
                                        UpdateVariableGetterAndSetter(colorGetterBuilder, colorSetterBuilder, v.name);
                                        break;
                                    case "Rect":
                                        UpdateVariableGetterAndSetter(rectGetterBuilder, rectSetterBuilder, v.name);
                                        break;
                                    case "Material":
                                        UpdateVariableGetterAndSetter(materialGetterBuilder, materialSetterBuilder, v.name);
                                        break;
                                    case "Texture":
                                        UpdateVariableGetterAndSetter(textureGetterBuilder, textureSetterBuilder, v.name);
                                        break;
                                    case "Quaternion":
                                        UpdateVariableGetterAndSetter(quaternionGetterBuilder, quaternionSetterBuilder, v.name);
                                        break;
                                    case "Object":
                                        UpdateVariableGetterAndSetter(objectGetterBuilder, objectSetterBuilder, v.name);
                                        break;
                                    default:
                                        // Type not supported by PlayMaker, do nothing
                                        break;
                                }
                            }
                            else if(v.variableType.Equals("array"))
                            {
                                UpdateArrayGetterAndSetter(arrayGetterBuilder, arraySetterBuilder, v.name);
                            }
                            // for lists, do nothing; they are not available in PlayMaker
                        }
                    }
                    sb.Append(GetEndCategory(key, categoryId, numberOfItems));
                    sb.AppendLine();
                    categoryId++;
                }
            }
            sb.AppendLine("        #region Getter/Setter Functions");

            AppendFooterAndAddToMainBuilder(floatGetterBuilder, floatSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(intGetterBuilder, intSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(boolGetterBuilder, boolSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(gameObjectGetterBuilder, gameObjectSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(stringGetterBuilder, stringSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(vector2GetterBuilder, vector2SetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(vector3GetterBuilder, vector3SetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(colorGetterBuilder, colorSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(rectGetterBuilder, rectSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(materialGetterBuilder, materialSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(textureGetterBuilder, textureSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(quaternionGetterBuilder, quaternionSetterBuilder, sb);
            AppendFooterAndAddToMainBuilder(objectGetterBuilder, objectSetterBuilder, sb);

            // Array setter has a different footer due to try/catch
            arrayGetterBuilder.Append(functionFooter);
            sb.Append(arrayGetterBuilder);
            arraySetterBuilder.Append(arraySetterFooter);
            sb.Append(arraySetterBuilder);

            sb.AppendLine("        #endregion //Getter/Setter Functions");

            sb.Append(sDataManagerFooter);

            Debug.Log("[EzDataUtility] Generating EzDataManagerVars.cs");
            string filePath = PathDataManager + "Scripts/" + "EzDataManagerVars.cs";
            System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            AssetDatabase.ImportAsset(filePath);
        }

        static void AppendFooterAndAddToMainBuilder(StringBuilder getter, StringBuilder setter, StringBuilder mainBuilder)
        {
            getter.Append(functionFooter);
            mainBuilder.Append(getter);
            setter.Append(functionFooter);
            mainBuilder.Append(setter);
        }

        static string GetVariableLine(string variableType, string typeName, string varName)
        {
            varName = CleanString(varName);
            StringBuilder sb = new StringBuilder();
            switch(variableType)
            {
                case "variable":
                    sb.AppendLine("        public " + typeName + " " + varName + ";");
                    break;
                case "array":
                    sb.AppendLine("        public " + typeName + "[] " + varName + ";");
                    break;
                case "list":
                    sb.AppendLine("        public List<" + typeName + "> " + varName + ";");
                    break;
            }

            return sb.ToString();
        }

        static void UpdateVariableGetterAndSetter(StringBuilder getter, StringBuilder setter, string varName)
        {
            getter.AppendLine(@"                case """ + varName + @""":");
            getter.AppendLine("                    value = EzDataManager.Instance." + varName + ";");
            getter.AppendLine("                    return true;");
            setter.AppendLine(@"                case """ + varName + @""":");
            setter.AppendLine("                    EzDataManager.Instance." + varName + " =  value ;");
            setter.AppendLine("                    return true;");
        }

        static void UpdateArrayGetterAndSetter(StringBuilder aGetter, StringBuilder aSetter, string arrayName)
        {
            aGetter.AppendLine(@"                case """ + arrayName + @""":");
            aGetter.AppendLine("                    array = EzDataManager.Instance." + arrayName + ";");
            aGetter.AppendLine("                    return true;");
            aSetter.AppendLine(@"                case """ + arrayName + @""":");
            aSetter.AppendLine("                    System.Array.Resize(ref EzDataManager.Instance." + arrayName + ", array.Length);");
            aSetter.AppendLine("                    System.Array.Copy(array, EzDataManager.Instance." + arrayName + ", array.Length);");
            aSetter.AppendLine("                    return true;");
        }

        static string GetStartCategory(string categoryName, int categoryId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        #region " + categoryName);
            sb.AppendLine("        public string " + EzDataManagerEditor.CATEGORY_START + categoryId + " = \"" + categoryName + "\";");
            return sb.ToString();
        }

        static string GetEndCategory(string categoryName, int categoryId, int numberofItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        public readonly int " + EzDataManagerEditor.CATEGORY_END + categoryId + " = " + numberofItems + ";");
            sb.AppendLine("        #endregion");
            return sb.ToString();
        }

        public static string CleanString(string s)
        {
            s = s.Trim();
            if(string.IsNullOrEmpty(s))
                return s;
            if(NumberChars.IndexOf(s[0]) >= 0)
                s = "_" + s; //do not allow the string to start with a number
            char[] c = s.ToCharArray();
            for(int i = 0; i < c.Length; i++)
                if(ValidChars.IndexOf(c[i]) < 0)
                    c[i] = '_'; //remove any character that is not in the ValidChars array; we replace it with '_'
            return new string(c);

        }
    }
}