using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace EquipmentSystem
{
    public class EquipmentFactory
    {
        private static EquipmentFactory instance = null;

        private EquipmentFactory() {
            InitFactory();
        }

        /// <summary>
        /// 工厂类中存储所有的小件装备
        /// </summary>
        private List<EquipmentLeaf> _samllEquipmentList =new List<EquipmentLeaf>();

        /// <summary>
        /// 工厂类中存储所有的中件装备
        /// </summary>
        private List<EquipmentComponent> _middleEquipmentList = new List<EquipmentComponent>();

        /// <summary>
        /// 工厂类中存储所有的大件装备
        /// </summary>
        private List<EquipmentComponent> _bigEquipmentList = new List<EquipmentComponent>();

        /// <summary>
        /// 获取唯一的工厂实例
        /// </summary>
        public static EquipmentFactory Instance {
            get
            {
                if (instance == null) {
                    instance = new EquipmentFactory();
                }
                return instance;
            }
        }

        /// <summary>
        /// 初始化工厂的属性
        /// </summary>
        private void InitFactory() {
            EquipmentHolder ceh = AssetDatabase.LoadAssetAtPath<EquipmentHolder>("Assets/Resources/Equipment.asset");
            if (ceh == null)
            {
                return;
            }
            _samllEquipmentList = ceh.equipmentLeaf;

            foreach (EquipmentComponent item in ceh.equipmentComponent) {
                if (item.equipmentType == EqunipmentType.BIG)
                {
                    _bigEquipmentList.Add(item);
                }
                else {
                    _middleEquipmentList.Add(item);
                }
            }
        }

        /// <summary>
        /// 根据查找的类型获取对应的小件装备
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<EquipmentLeaf> GetSmallEquipmentBySearchType(SearchType type) {
            List<EquipmentLeaf> itemList = new List<EquipmentLeaf>();
            foreach (EquipmentLeaf item in _samllEquipmentList) {
                if (item.seaechType == type) {
                    itemList.Add(item);
                }
            }
            return itemList;
        }

        /// <summary>
        /// 根据查找的类型获取对应的大件装备
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<EquipmentComponent> GetBigEquipmentBySerchType(SearchType type) {
            List<EquipmentComponent> itemList = new List<EquipmentComponent>();
            foreach (EquipmentComponent item in _bigEquipmentList) {
                if (item.seaechType == type) {
                    itemList.Add(item);
                }
            }
            return itemList;
        }

        /// <summary>
        /// 根据查找的类型获取对应的大件装备
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<EquipmentComponent> GetMiddleEquipmentBySearchType(SearchType type) {
            List<EquipmentComponent> itemList = new List<EquipmentComponent>();
            foreach (EquipmentComponent item in _middleEquipmentList) {
                if (item.seaechType == type) {
                    itemList.Add(item);
                }
            }
            return itemList;
        }

        /// <summary>
        /// 根据装备Id获取指定的装备
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public EquipmentLeaf GetLeafEquipmentById(int equipment) {
            foreach (EquipmentLeaf leaf in _samllEquipmentList) {
                if (leaf.equipmentId == equipment) {
                    return leaf;
                }
            }
            return null;
        }

        public EquipmentComponent GetMiddleEquipmentById(int equipmentId) {
            foreach (EquipmentComponent item in _middleEquipmentList) {
                if (item.equipmentId == equipmentId) {
                    return item;
                }
            }
            
            return null;
        }

        public EquipmentComponent GetBigEquipmentById(int equipmentId) {
            foreach (EquipmentComponent item in _bigEquipmentList)
            {
                if (item.equipmentId == equipmentId)
                {
                    return item;
                }
            }
            return null;
        }
    }
}