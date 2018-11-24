using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

[DataContract]
public class Stage
{   [DataMember]
    public StageInfoData stage_info_data;

    [DataContract]
    public class StageInfoData
    {
        [DataMember]
        public List<StageI> stage_i;    

        public class StageI
        {   
            [DataMember]
            public int s_id;
            [DataMember]
            public string bullet;
            [DataMember]
            public string restbullet;
        }            
    }
}

