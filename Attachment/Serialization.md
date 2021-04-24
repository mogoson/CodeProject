# Serialization

## Summary
- Serialize and Deserialize  List  by JsonUtility.
- Serialize and Deserialize  Dictionary by JsonUtility.

## Environment

- Unity 5.3 or above.
- .Net Framework 3.5 or above.

## Platform

- WindowsPlayer.
- Android.

## Demand

- Serialize/Deserialize  List  by JsonUtility.
- Serialize/Deserialize  Dictionary by JsonUtility.

## Implemented

- ListAvatar.cs: .
- DictionaryAvatar.cs: .
- JsonUtilityPro.cs: .

## Usage

- Custom type.

  ```c#
  // Must with Serializable Attribute.
  [Serializable]
  class TestCalss
  {
      // private field must with SerializeField Attribute.
      [SerializeField]
      private string testField_0;
      
      // public field is OK.
      public string testField_1;
      
      public TestCalss(string testField_0)
      {
          this.testField_0=testField_0;
      }
  }
  ```

  

- Serialize List to json.

  ```c#
  // Use base type is OK, example int, string...
  var testList=new List<TestCalss>()
  {
      new TestCalss("Field_0")
      {
          testField_1="Field_1"
      }；
  };
  
  var avatarJson = JsonUtilityPro.ToJson<TestCalss>(testList);
  // avatarJson is
  // {"source":[{"testField_1":"Field_0","testField_1":"Field_1"}]}
  
  var listJson = JsonUtilityPro.FromListAvatar(avatarJson);
  // listJson is
  // [{"testField_1":"Field_0","testField_1":"Field_1"}]
  ```

- Deserialize List from json.

  ```c#
  // avatarJson is
  // {"source":[{"testField_1":"Field_0","testField_1":"Field_1"}]}
  var list = JsonUtilityPro.FromJson<TestCalss>(avatarJson);
  
  // listJson is
  // [{"testField_1":"Field_0","testField_1":"Field_1"}]
  var avatarJson = JsonUtilityPro.ToListAvatar(listJson);
  var list = JsonUtilityPro.FromJson<TestCalss>(avatarJson);
  ```

- Serialize Dictionary to json.

  ```c#
  var testDic = new Dictionary<int, string>()
  {
    {0, "test0"},
      {1, "test1"}
  };
  
  var avatarJson = JsonUtilityPro.ToJson<TestCalss>(testDic);
  // avatarJson is
  // {"source":{"keys":[0,1],"values":["test0","test1"]}}
  ```

- Deserialize Dictionary from json.

  ```c#
  // avatarJson is
  // {"source":{"keys":[0,1],"values":["test0","test1"]}}
  var dic = JsonUtilityPro.FromJson<int, string>(avatarJson);
  ```

------

[Previous](../README.md)

------

Copyright © 2021 Mogoson. All rights reserved.	mogoson@outlook.com