using Conan.Model;
using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// WxOrderBd
    /// </summary>
    public class WxOrderBd
    {
        //#region ��ѡ��  ����

        ///// <summary>
        ///// ���ϱ��
        ///// </summary>

        //public virtual string[] OrderMaterialCode { get; set; }

        ///// <summary>
        ///// ��������
        ///// </summary>

        //public virtual string[] OrderMaterialName { get; set; }


        ///// <summary>
        ///// ���Ͻ����ۣ�
        ///// </summary>

        //public virtual string[] OrderMaterialWage { get; set; }

        ///// <summary>
        ///// ���Ͻ�� �ܼ�
        ///// </summary>

        //public virtual string[] OrderMaterialTotalWage { get; set; }


        ///// <summary>
        ///// ����
        ///// </summary>

        //public virtual string[] OrderMaterialNum { get; set; }




        ///// <summary>
        ///// ��λ
        ///// </summary>

        //public virtual string[] OrderMaterialUnit { get; set; }


        //#endregion

        #region ������
        /// <summary>
        /// ���� ���
        /// </summary>
        public virtual string[] MaterialSNo { get; set; }

        /// <summary>
        /// ���Ͻ��
        /// </summary>

        public virtual string[] MaterialWage { get; set; }

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


      

        /// <summary>
        /// �Ӷ������
        /// </summary>
        public virtual string OrderSubPrices { get; set; }


    }

}