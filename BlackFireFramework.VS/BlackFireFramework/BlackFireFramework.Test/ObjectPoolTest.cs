using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class ObjectPoolTest
    {
        [TestMethod]
        public void TestMethod_ObjectPool_DefaultImpl()
        {
            ObjectPool.CreatePool("TestPool_DefaultImpl", int.MaxValue);
        }

        [TestMethod]
        public void TestMethod_ObjectPool_CustomImpl()
        {
            ObjectPool.CreatePool("TestPool_CustomImpl", int.MaxValue, typeof(TestPool));
        }


        private sealed class TestPool : ObjectPool.PoolBase
        {
            public TestPool(string name, int poolCapacity) : base(name, poolCapacity)
            {
                Debug.WriteLine(name+"  "+poolCapacity);
            }

            public override int Count => throw new NotImplementedException();

            public override int InCount => throw new NotImplementedException();

            public override int OutCount => throw new NotImplementedException();

            public override void Lock(ObjectPool.ObjectBase @object)
            {
                throw new NotImplementedException();
            }

            public override void Recycle(ObjectPool.ObjectBase @object)
            {
                throw new NotImplementedException();
            }

            public override void RecycleAll()
            {
                throw new NotImplementedException();
            }

            public override void Release(ObjectPool.ObjectBase @object)
            {
                throw new NotImplementedException();
            }

            public override void ReleaseAll()
            {
                throw new NotImplementedException();
            }

            public override void ReleaseIn()
            {
                throw new NotImplementedException();
            }

            public override void ReleaseOut()
            {
                throw new NotImplementedException();
            }



            public override ObjectPool.ObjectBase Spawn(Type objectType, Predicate<ObjectPool.ObjectBase> predicate = null, Func<object> argsCallback = null)
            {
                throw new NotImplementedException();
            }

            public override void UnLock(ObjectPool.ObjectBase @object)
            {
                throw new NotImplementedException();
            }

            protected override void OnDestroy()
            {
                throw new NotImplementedException();
            }
        }



        [TestMethod]
        public void TestMethod_ObjectPool_DefaultObjectPool()
        {

            var pool = ObjectPool.CreatePool("TestPoolCapacity_CustomImpl",5);
            ObjectTest recycleObject = pool.Spawn(typeof(ObjectTest)) as ObjectTest; // 1
            //所属对象池。
            Debug.WriteLine(recycleObject.PoolName);
            

            Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode()); //2
            Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode()); //3
            Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode()); //4
            Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode()); //5

            Debug.WriteLine(recycleObject.GetHashCode());

            //容量已满。
            //回收一个对象。
            pool.Recycle(recycleObject);

            Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode());

            //容量已满。
            //释放一个对象。
            pool.Release(recycleObject); // 4

            recycleObject = pool.Spawn(typeof(ObjectTest)) as ObjectTest; //5
            Debug.WriteLine(recycleObject.GetHashCode());
            //加锁操作。
            pool.Lock(recycleObject);
            Debug.WriteLine("Lock State: "+recycleObject.Lock);
            //尝试回收加锁的对象。
            pool.Recycle(recycleObject); //不能回收
            //尝试再产出一个对象。
            try
            {
                Debug.WriteLine(pool.Spawn(typeof(ObjectTest)).GetHashCode());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            pool.UnLock(recycleObject);
            //尝试回收加锁的对象。
            pool.Recycle(recycleObject); //可以回收
            Debug.WriteLine("解锁回收后再次产出"+pool.Spawn(typeof(ObjectTest)).GetHashCode());


            //容量和数量。
            Debug.WriteLine("容量:"+pool.Capacity + "数量:" + pool.Count);

        }

        private sealed class ObjectTest : ObjectPool.ObjectBase
        {

        }

    }
}
