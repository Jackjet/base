using Conan.Model;
using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// �������
    /// </summary>
    public class OrderAdd
    {
        #region ��ѡ��  ����

        /// <summary>
        /// ���ϱ��
        /// </summary>

        public virtual string[] OrderMaterialCode { get; set; }

        /// <summary>
        /// ��������
        /// </summary>

        public virtual string[] OrderMaterialName { get; set; }


        /// <summary>
        /// ���Ͻ����ۣ�
        /// </summary>

        public virtual string[] OrderMaterialWage { get; set; }

        /// <summary>
        /// ���Ͻ�� �ܼ�
        /// </summary>

        public virtual string[] OrderMaterialTotalWage { get; set; }


        /// <summary>
        /// ����
        /// </summary>

        public virtual string[] OrderMaterialNum { get; set; }




        /// <summary>
        /// ��λ
        /// </summary>

        public virtual string[] OrderMaterialUnit { get; set; }


        #endregion

        #region ����ָ����Ա
        /// <summary>
        /// ���� ���
        /// </summary>
        public virtual string[] SCCode { get; set; }


        /// <summary>
        /// ˾�� ���
        /// </summary>
        public virtual string[] SCarCode { get; set; }




        /// <summary>
        /// ��Ա ���
        /// </summary>
        public virtual string[] SNo { get; set; }

        /// <summary>
        /// ��Ա����
        /// </summary>
        public virtual string[] SName { get; set; }

        /// <summary>
        /// �绰
        /// </summary>
        public virtual string[] STel { get; set; }





        #endregion

        #region ������
        /// <summary>
        /// ����
        /// </summary>
        public virtual string[] Snum { get; set; }


        /// <summary>
        /// �ܼ۸�
        /// </summary>
        public virtual string[] Samount { get; set; }
        #endregion

        #region ��ͬʱ��
        /// <summary>
        /// ��ͬ��ʼʱ��
        /// </summary>
        public virtual DateTime? htStartTime { get; set; }
        /// <summary>
        /// ��ͬ����ʱ��
        /// </summary>
        public virtual DateTime? htendTime { get; set; } 
        #endregion



        /// <summary>
        /// �ͻ�Id
        /// </summary>
        public virtual int MemberId { get; set; }


        /// <summary>
        /// �ӵ���
        /// </summary>
        public virtual string BillItemNo { get; set; }



        /// <summary>
        /// ���ݺ�
        /// </summary>
        public virtual string BillNo { get; set; }


        /// <summary>
        /// ҵ������
        /// </summary>
        public virtual int BusinessChannel { get; set; }

   

        /// <summary>
        /// ������
        /// </summary>
        public virtual string Developer { get; set; }

        /// <summary>
        /// �ŵ�id
        /// </summary>
        public virtual int StoreId { get; set; }





        /// <summary>
        /// ������Ʒid  ������Ŀ
        /// </summary>
        public virtual int ProductId { get; set; }

        #region ������

        /// <summary>
        ///���� ��ַid  ������
        /// </summary>
        public virtual int Rid { get; set; }
        /// <summary>
        /// ��id
        /// </summary>
        public virtual int CityId { get; set; }
        /// <summary>
        /// ����id
        /// </summary>
        public virtual int AreaId { get; set; }



        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public virtual string Street { get; set; } = "";

        /// <summary>
        /// ����վ��
        /// </summary>
        public virtual string BusStation { get; set; } = "";


        #endregion

        #region Ŀ�ĵ�

        /// <summary>
        ///���� ��ַid  Ŀ�ĵ�
        /// </summary>
        public virtual int ERid { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        public virtual int EndCityId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual int EndAreaId { get; set; }

        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public virtual string EndStreet { get; set; } = "";



        /// <summary>
        /// ����վ��
        /// </summary>
        public virtual string EndBusStation { get; set; } = "";


        #endregion

        /// <summary>
        /// ��ϵ��
        /// </summary>
        public virtual string Contact { get; set; } = "";
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public virtual string Tel { get; set; } = "";


        /// <summary>
        /// ����ʼʱ��
        /// </summary>

        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
      
        public virtual DateTime? EndTime { get; set; }




        /// <summary>
        /// Ա�����/�������  ָ������
        /// </summary>
        public virtual string[] ServiceNo { get; set; }

        /// <summary>
        /// ����Ա��/����  ����  ָ������
        /// </summary>
        public virtual int[] WaiterType { get; set; }



        //sku  ��ʵ��



        /// <summary>
        /// ����ע
        /// </summary>
        public virtual string ServiceRemark { get; set; }
        /// <summary>
        /// ������ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// �Ƿ�ʹ�����֧��
        /// </summary>
        public virtual int IsRequired { get; set; }


        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public virtual int IsFace { get; set; }


        #region  ��� sku 
        /// <summary>
        /// sku1 -��� sku 
        /// </summary>
        public virtual string Sku1 { get; set; } = "";
        /// <summary>
        /// sku2-��� sku 
        /// </summary>
        public virtual string Sku2 { get; set; } = "";

        /// <summary>
        /// sku3-��� sku 
        /// </summary>
        public virtual string Sku3 { get; set; } = "";

        /// <summary>
        /// ��������1-��� sku 
        /// </summary>
        public virtual int sale1 { get; set; } = 0;

        /// <summary>
        /// ��������2-��� sku 
        /// </summary>
        public virtual int sale2 { get; set; } =0;


        /// <summary>
        /// ��������id1-��� sku 
        /// </summary>
        public virtual int SkuUnitId1 { get; set; } = 0;

        /// <summary>
        /// ��������id2-��� sku 
        /// </summary>
        public virtual int SkuUnitId2 { get; set; } = 0;
        #endregion

        /// <summary>
        /// �Ӷ������
        /// </summary>
        public virtual string OrderSubPrices { get; set; }

        #region  �ύsku

        /// <summary>
        /// sku1
        /// </summary>
        public virtual string[] SkuName1 { get; set; }

        /// <summary>
        /// sku2
        /// </summary>
        public virtual string[] SkuName2 { get; set; }

        /// <summary>
        /// sku3
        /// </summary>
        public virtual string[] SkuName3 { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual string[] SinPrice { get; set; }

        /// <summary>
        /// ����id1
        /// </summary>
        public virtual int[] SalesId1 { get; set; }

        /// <summary>
        /// ����1����
        /// </summary>
        public virtual int[] SalesIdNum1 { get; set; }

        /// <summary>
        /// ����id2
        /// </summary>
        public virtual int[] SalesId2 { get; set; }

        /// <summary>
        /// ����2����
        /// </summary>
        public virtual int[] SalesIdNum2 { get; set; }

        /// <summary>
        /// sku �ܼ۸�
        /// </summary>
        public virtual string[] TotalOrderPrices { get; set; }

        #endregion


    }

    #region �Ӷ�����ϸsku����
    /// <summary>
    /// �Ӷ�����ϸsku����
    /// </summary>
    //public class OrderItemSkuDes
    //{

    //    /// <summary>
    //    /// sku1
    //    /// </summary>
    //    public virtual string SkuName1 { get; set; }

    //    /// <summary>
    //    /// sku2
    //    /// </summary>
    //    public virtual string SkuName2 { get; set; }

    //    /// <summary>
    //    /// sku3
    //    /// </summary>
    //    public virtual string SkuName3 { get; set; }



    //    /// <summary>
    //    /// ����
    //    /// </summary>
    //    public virtual string SinPrice { get; set; }



    //    /// <summary>
    //    /// ����id1
    //    /// </summary>
    //    public virtual int SalesId1 { get; set; }


    //    /// <summary>
    //    /// ����1����
    //    /// </summary>
    //    public virtual int SalesIdNum1 { get; set; }



    //    /// <summary>
    //    /// ����id2
    //    /// </summary>
    //    public virtual int SalesId2 { get; set; }


    //    /// <summary>
    //    /// ����2����
    //    /// </summary>
    //    public virtual int SalesIdNum2 { get; set; }



    //    /// <summary>
    //    /// sku �ܼ۸�
    //    /// </summary>
    //    public virtual string TotalOrderPrices { get; set; }




    //}

    public class SkuDes
    {
        /// <summary>
        /// sku
        /// </summary>
        public List<string> SkuNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Unit> Units { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string SinPrice { get; set; }

        /// <summary>
        /// sku �ܼ۸�
        /// </summary>
        public virtual string TotalOrderPrices { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// ֵ
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
    }


    #endregion

}