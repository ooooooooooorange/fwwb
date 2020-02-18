## Session内容
| 字段 | 属性       | 创建         | 说明                 |
| ---- | ---------- | ------------ | -------------------- |
| Usr  | Model.User | 于成功登录后 | 储存该实列的用户信息 |

## ViewBag内容

| 字段         | 属性                             | 使用                    | 说明                                                         |
| ------------ | -------------------------------- | ----------------------- | ------------------------------------------------------------ |
| Title        | string                           | 网页文件首句            | 网页标题                                                     |
| UsrName      | string                           | 除登录与错误界面        | 储存该实列的用户姓名                                         |
| RepDealNames | List<string>                     | RepairDeal生成          | 储存申请列表人姓名列表                                       |
| ToolIDs      | List<string>                     | ToolInformation生成     | 储存可查看的工夹具的编号列表                                 |
| UserPair     | List<KeyValuePair<string,int[]>> | Admin.Power用户权限管理 | 列表储存用户信息，pair中first为用户姓名，second为用户角色列表，/**/详细后面再讨论 |
|              |                                  |                         |                                                              |



