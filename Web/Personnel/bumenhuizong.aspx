<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bumenhuizong.aspx.cs" Inherits="Web.Personnel.bumenhuizong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
    
<body  style="    margin: 0;">
        <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        }
        
        body {
            background: linear-gradient(135deg, #f5f7fa 0%, #e4e8f0 100%);
            padding: 20px;
            min-height: 100vh;
            display: flex;
        }
       .ti {
            background: linear-gradient(135deg, #2E8B57 0%, #3CB371 30%, #20B2AA 100%);
            color: white;
            padding: 6px 30px;
            border-radius: 12px 12px 0 0;
            display: flex;
            justify-content: space-between;
            align-items: center;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
        }
        
        .ti h1 {
            margin: 0;
            font-size: 24px;
            font-weight: 700;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
            z-index: 2;
        }
        
        .ti::before {
            content: "";
            position: absolute;
            top: -50%;
            right: -50%;
            width: 80%;
            height: 200%;
            background: rgba(255, 255, 255, 0.1);
            transform: rotate(25deg);
            z-index: 1;
        }
        
        .ti-content {
            display: flex;
            align-items: center;
            z-index: 2;
        }
        
        .ti-stats {
            display: flex;
            gap: 25px;
            margin-right: 20px;
        }
        
        .stat-item {
            text-align: center;
            padding: 0 15px;
            border-right: 1px solid rgba(255, 255, 255, 0.3);
        }
        
        .stat-item:last-child {
            border-right: none;
        }
        
        .stat-value {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        .stat-label {
            font-size: 14px;
            opacity: 0.9;
        }
        
        /* 表单区域样式 */
        .header-top {
            background: white;
            padding: 20px 30px;
            border-radius: 0 0 12px 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            align-items: center;
            margin-bottom:10px;
        }
        
        .header-top label {
            font-weight: 600;
            color: #2E8B57;
            margin-right: 8px;
            min-width: 80px;
            display: inline-block;
        }
        
        .top_select_input {
            /*padding: 12px 15px;*/
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 15px;
            width: 150px;
            transition: all 0.3s;
        }
        
        .top_select_input:focus {
            outline: none;
            border-color: #3CB371;
            box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        }
        
        .top_bt {
            background: linear-gradient(to right, #2E8B57, #3CB371);
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            min-width: 80px;
            height: 42px;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            line-height:8px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to right, #26734d, #2fa866);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 响应式调整 */
        @media (max-width: 768px) {
            .ti {
                flex-direction: column;
                text-align: center;
                gap: 20px;
            }
            
            .ti-stats {
                margin-right: 0;
                justify-content: center;
            }
            
            .header-top {
                flex-direction: column;
                align-items: stretch;
            }
            
            .top_select_input {
                width: 100%;
            }
        }

        .personnel-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        
        table#ridView1 th[scope="col"],
        table th[scope="col"] {
            background: linear-gradient(to bottom, #2E8B57, #3CB371) !important;
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            border: none !important;
        }
        
        table#GridView1 tr.item:nth-child(even),
        table tr.item:nth-child(even) {
            background: linear-gradient(to bottom, #FFF9C4, #FFF8E1) !important;
        }

        /* 针对奇数行 */
        table#GridView1 tr.item:nth-child(odd),
        table tr.item:nth-child(odd) {
            background: linear-gradient(to bottom, #E0F2F1, #C8E6C9) !important;
        }

        /* 行悬停效果 */
        table#GridView1 tr.item:hover,
        table tr.item:hover {
            background: linear-gradient(to bottom, #E1F5FE, #B3E5FC) !important;
            cursor: pointer;
        }

        /* 确保单元格也有背景色 */
        table#GridView1 tr.item td,
        table tr.item td {
            border: 1px solid #ddd !important;
            padding: 10px !important;
        }

        /* 针对可能的内联样式 */
        tr[class*="item"] {
            background-image: none !important; /* 清除可能的内联背景 */
        }

        table {
            border-collapse: separate !important;
            border-spacing: 0 !important;
            width: 100%;
            border-radius: 8px !important;
            overflow: hidden !important;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15), 
                        0 2px 6px rgba(0, 0, 0, 0.1) !important;
            background: white !important;
            border: 1px solid #ddd !important;
        }

        /* 表头立体效果 */
        table th {
            background: linear-gradient(to bottom, #4CAF50, #2E8B57) !important;
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.3) !important;
            border-bottom: 2px solid #1B5E20 !important;
            position: relative;
        }

        /* 表头底部阴影，增强立体感 */
        table th:after {
            content: '';
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 2px;
            background: linear-gradient(to right, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.2) 50%, 
                rgba(0,0,0,0.1) 100%) !important;
        }

        /* 单元格立体效果 */
        table td {
            padding: 12px 15px !important;
            border: 1px solid #e0e0e0 !important;
            position: relative;
        }

        /* 单元格内部阴影，增强立体感 */
        table td:before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.05) !important;
            pointer-events: none;
        }

        /* 斑马条纹效果 - 立体版本 */
        table tr:nth-child(even) td {
            background: linear-gradient(to bottom, #f9f9f9, #f0f0f0) !important;
        }

        table tr:nth-child(odd) td {
            background: linear-gradient(to bottom, #ffffff, #f7f7f7) !important;
        }

        /* 行悬停效果 - 立体版本 */
        table tr:hover td {
            background: linear-gradient(to bottom, #e8f5e9, #c8e6c9) !important;
            box-shadow: inset 0 0 10px rgba(46, 139, 87, 0.1) !important;
        }

        /* 表格底部阴影，增强整体立体感 */
        table:after {
            content: '';
            position: absolute;
            bottom: -5px;
            left: 5px;
            right: 5px;
            height: 5px;
            background: linear-gradient(to bottom, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.05) 50%, 
                transparent 100%) !important;
            border-radius: 0 0 8px 8px;
            z-index: -1;
        }

        /* 为表格容器添加额外阴影增强立体感 */
        .table-container {
            position: relative;
            margin: 20px 0;
        }

        .table-container:before {
            content: '';
            position: absolute;
            top: 5px;
            left: 10px;
            right: 10px;
            bottom: -5px;
            background: rgba(0,0,0,0.05);
            border-radius: 8px;
            z-index: -1;
        }
    </style>
    
    <form id="form1" runat="server">
    <div>
        <div class="ti">
            <h1 >部门汇总</h1>
        </div>


            <div class="header-top">
            <asp:Label ID="Label1" runat="server" Height="30px" Text="部门：" Width="80px" style="text-align:center"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="C" DataValueField="C" CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888">
            </asp:DropDownList>
            <input type="date" name="ks"/>
            <input type="date" name="js"/>
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click"  CssClass="top_bt" style="margin-right:-10px;height:30px;width:80px" />
            <asp:Button ID="Button2" runat="server" Text="部门详情" OnClick="Button2_Click"  CssClass="top_bt" style="margin-right:-10px;height:30px;width:80px" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有"  CssClass="top_bt" style="margin-right:-10px;height:30px;width:80px" />
            <asp:Button ID="Button4" runat="server" Text="生成Excel" OnClick="Button4_Click"  CssClass="top_bt" style="margin-right:-10px;height:30px;width:80px" />
          </div> 
                 <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString26 %>" SelectCommand="SELECT [C], [BD] FROM [gongzi_gongzimingxi] WHERE ([BD] = @gongsi)  GROUP BY [C], [BD]">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"  ConnectionString="<%$ ConnectionStrings:yaoConnectionString25 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="SELECT C,BD,count(DISTINCT B) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE (([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%')) AND convert(date,BC)&gt;=@ks and convert(date,BC)&lt;=@js GROUP BY c,bd" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC, [BD] = @BD WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="ks" SessionField="ks" Type="String" />
                <asp:SessionParameter Name="js" SessionField="js" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString24 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="SELECT C,BD,count(DISTINCT B) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE [BD] like '%上海%'  GROUP BY c,bd" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC, [BD] = @BD WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="id" AllowPaging="True" >
            <Columns>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="人数" SortExpression="ID" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="基本工资" SortExpression="G" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="效绩工资" SortExpression="H" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="岗位工资" SortExpression="I" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="标准工资" SortExpression="J" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="跨度工资" SortExpression="K" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="职称津贴" SortExpression="L" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="M" HeaderText="月出勤天数" SortExpression="M" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="加班时间" SortExpression="N" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="加班费" SortExpression="O" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="全勤应发" SortExpression="P" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="缺勤天数" SortExpression="Q" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="缺勤扣款" SortExpression="R" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="迟到天数" SortExpression="S" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="迟到扣款" SortExpression="T" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="应发工资" SortExpression="U" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="社保基数" SortExpression="V" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="医疗技术" SortExpression="W" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="公积金基数" SortExpression="X" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="年金基数" SortExpression="Y" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="企业医疗" SortExpression="AB" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AE" HeaderText="企业公积金" SortExpression="AE" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AF" HeaderText="企业年金" SortExpression="AF" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AG" HeaderText="滞纳金" SortExpression="AG" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AH" HeaderText="利息" SortExpression="AH" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AI" HeaderText="企业小计" SortExpression="AI" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="个人医疗" SortExpression="AL" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AM" HeaderText="大额医疗" SortExpression="AM" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AN" HeaderText="个人公积金" SortExpression="AN" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="个人年金4%" SortExpression="AO" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AP" HeaderText="滞纳金" SortExpression="AP" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AQ" HeaderText="利息" SortExpression="AQ" HeaderStyle-Font-Bold="true" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AR" HeaderText="个人小计" SortExpression="AR" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ASA" HeaderText="税前工资" SortExpression="ASA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ATA" HeaderText="应税工资" SortExpression="ATA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AU" HeaderText="税率" SortExpression="AU" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AV" HeaderText="扣除数" SortExpression="AV" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AW" HeaderText="代扣个人所得税" SortExpression="AW" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AX" HeaderText="1%年金" SortExpression="AX" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AY" HeaderText="实发工资" SortExpression="AY" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD"  Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
    </form>
</body>
</html>
