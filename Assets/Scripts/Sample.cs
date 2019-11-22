using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UniPromise;

public class Sample : MonoBehaviour
{
//    private Promise<CUnit> apiResponseChain;
    
    void Start()
    {
//        ActionMethod(() => {
//            Debug.Log("1");
//            ActionMethod(() => {
//                Debug.Log("2");
//                ActionMethod(() => {
//                    Debug.Log("3");
//                });
//            });
//        });
//        
//        var promise = new Deferred<CUnit>();
//        promise.Done(_ =>
//        {
//            Debug.Log("4");
//        }).Done(_ =>
//        {
//            Debug.Log("5");
//        }).Done(_ =>
//        {
//            Debug.Log("6");
//        });
//        promise.Resolve(CUnit.Default);
//        
//        Debug.Log("promise.State = " + promise.State);
//        Debug.Log("promise.IsResolved = " + promise.IsResolved);
//        Debug.Log("promise.IsRejected = " + promise.IsRejected);
//        Debug.Log("promise.IsPending = " + promise.IsPending);
//        Debug.Log("promise.IsDisposed = " + promise.IsDisposed);

//        PromiseResolved().Then(_ =>
//        {
//            Debug.Log("1");
//            return PromiseResolved();
//        }).Then(_ =>
//        {
//            Debug.Log("2");
//            return PromiseResolved();
//        }).Then(_ =>
//        {
//            Debug.Log("3");
//            return PromiseResolved();
//        }).Then(_ => PromiseResolved(), _ => PromiseRejected());

//        var promise = new Deferred<CUnit>();
//        promise.Then(_ =>
//            {
//                Debug.Log("resolve");
//                return Promises.Resolved(CUnit.Default);
//            }, _ =>
//            {
//                Debug.Log("reject");
//                return Promises.Rejected<CUnit>(new SystemException());
//            }).Then(_ =>
//        {
//            Debug.Log("rresolve2");
//            return Promises.Resolved(CUnit.Default);
//        });
//        promise.Resolve(CUnit.Default);
//        promise.Reject(new SystemException());

//        var promise = new Deferred<CUnit>();
//        promise.Then(_ =>
//        {
//            Debug.Log("done");
//            return Promises.Resolved(CUnit.Default);
//        }, _ =>    
//        {
//            Debug.Log("fail");
//            return Promises.Rejected<CUnit>(new SystemException());
//        }).Finally(() =>
//        {
//            Debug.Log("Finally");
//        });
//        
//        promise.Reject(new SystemException());
//        var promise = new Deferred<CUnit>();
//        promise.Select(_ => "done").Done(str => Debug.Log(str))
//            .Select(_ => "fail").Fail(str => Debug.Log(str));
//        promise.Resolve(CUnit.Default);
//        promise.Reject(new SystemException());

        var promise = new Deferred<CUnit>();
        promise.Then(_ => CallApi()).Then(_ =>
        {
            return null;
        }, _ =>
        {
            SaveApiToDatabase();
            return Promises.Resolved(CUnit.Default);
        }).Then(_ => OutputMessage());
        promise.Resolve(CUnit.Default);
    }
    
    private Promise<CUnit> CallApi()
    {
        Debug.Log("CallApi called");
        return Promises.Rejected<CUnit>(new SystemException());
    }
    
    private Promise<CUnit> SaveApiToDatabase()
    {
        Debug.Log("SaveApiToDatabase called");
        var promise = new Deferred<CUnit>();
        promise.Then<CUnit>(_ =>
        {
            Debug.Log("db saved");
            return null;
        }, _ =>
        {
            Debug.Log("db is not saved");
            return null;
        });
        promise.Reject(new SystemException());
        return promise;
    }

    private Promise<CUnit> OutputMessage()
    {
        Debug.Log("OutputMessage");
        throw new NotImplementedException();
    }
}
    