#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::ArgumentOutOfRange(System.String)
extern void Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2 (void);
// 0x00000003 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000004 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000005 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000006 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000007 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000008 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000009 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectMany(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x0000000A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectManyIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x0000000B System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Take(System.Collections.Generic.IEnumerable`1<TSource>,System.Int32)
// 0x0000000C System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::TakeIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Int32)
// 0x0000000D System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000E System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderByDescending(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000F System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x00000010 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Distinct(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::DistinctIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000012 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Union(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000013 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::UnionIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000014 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Intersect(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000015 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::IntersectIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000016 TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000017 System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000018 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::OfType(System.Collections.IEnumerable)
// 0x00000019 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::OfTypeIterator(System.Collections.IEnumerable)
// 0x0000001A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Cast(System.Collections.IEnumerable)
// 0x0000001B System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::CastIterator(System.Collections.IEnumerable)
// 0x0000001C TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001D TSource System.Linq.Enumerable::FirstOrDefault(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001E TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001F TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000020 TSource System.Linq.Enumerable::ElementAt(System.Collections.Generic.IEnumerable`1<TSource>,System.Int32)
// 0x00000021 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Empty()
// 0x00000022 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000023 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000024 System.Boolean System.Linq.Enumerable::All(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000025 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000026 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000027 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000028 TAccumulate System.Linq.Enumerable::Aggregate(System.Collections.Generic.IEnumerable`1<TSource>,TAccumulate,System.Func`3<TAccumulate,TSource,TAccumulate>)
// 0x00000029 System.Int32 System.Linq.Enumerable::Sum(System.Collections.Generic.IEnumerable`1<System.Int32>)
extern void Enumerable_Sum_m6CFC8CEAC70AE3C469A5D1993FAF8EEEC6A06FB5 (void);
// 0x0000002A System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x0000002B TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x0000002C System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x0000002D System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x0000002E System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x0000002F System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x00000030 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000031 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000032 System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x00000033 System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000034 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x00000035 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000036 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000037 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000038 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000039 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000003A System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000003B System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x0000003C System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x0000003D System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x0000003E System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000003F System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000040 System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000041 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x00000042 System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x00000043 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000044 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000045 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000046 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000047 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000048 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000049 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000004A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000004B System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000004C System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x0000004D System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x0000004E System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000004F System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000050 System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000051 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x00000052 System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x00000053 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000054 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000055 System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000056 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000057 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000058 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000059 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::.ctor(System.Int32)
// 0x0000005A System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.IDisposable.Dispose()
// 0x0000005B System.Boolean System.Linq.Enumerable/<SelectManyIterator>d__17`2::MoveNext()
// 0x0000005C System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally1()
// 0x0000005D System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally2()
// 0x0000005E TResult System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x0000005F System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.Reset()
// 0x00000060 System.Object System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.get_Current()
// 0x00000061 System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x00000062 System.Collections.IEnumerator System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerable.GetEnumerator()
// 0x00000063 System.Void System.Linq.Enumerable/<TakeIterator>d__25`1::.ctor(System.Int32)
// 0x00000064 System.Void System.Linq.Enumerable/<TakeIterator>d__25`1::System.IDisposable.Dispose()
// 0x00000065 System.Boolean System.Linq.Enumerable/<TakeIterator>d__25`1::MoveNext()
// 0x00000066 System.Void System.Linq.Enumerable/<TakeIterator>d__25`1::<>m__Finally1()
// 0x00000067 TSource System.Linq.Enumerable/<TakeIterator>d__25`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x00000068 System.Void System.Linq.Enumerable/<TakeIterator>d__25`1::System.Collections.IEnumerator.Reset()
// 0x00000069 System.Object System.Linq.Enumerable/<TakeIterator>d__25`1::System.Collections.IEnumerator.get_Current()
// 0x0000006A System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<TakeIterator>d__25`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x0000006B System.Collections.IEnumerator System.Linq.Enumerable/<TakeIterator>d__25`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000006C System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::.ctor(System.Int32)
// 0x0000006D System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::System.IDisposable.Dispose()
// 0x0000006E System.Boolean System.Linq.Enumerable/<DistinctIterator>d__68`1::MoveNext()
// 0x0000006F System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::<>m__Finally1()
// 0x00000070 TSource System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x00000071 System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerator.Reset()
// 0x00000072 System.Object System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerator.get_Current()
// 0x00000073 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x00000074 System.Collections.IEnumerator System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000075 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::.ctor(System.Int32)
// 0x00000076 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::System.IDisposable.Dispose()
// 0x00000077 System.Boolean System.Linq.Enumerable/<UnionIterator>d__71`1::MoveNext()
// 0x00000078 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::<>m__Finally1()
// 0x00000079 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::<>m__Finally2()
// 0x0000007A TSource System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x0000007B System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerator.Reset()
// 0x0000007C System.Object System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerator.get_Current()
// 0x0000007D System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x0000007E System.Collections.IEnumerator System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000007F System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::.ctor(System.Int32)
// 0x00000080 System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::System.IDisposable.Dispose()
// 0x00000081 System.Boolean System.Linq.Enumerable/<IntersectIterator>d__74`1::MoveNext()
// 0x00000082 System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::<>m__Finally1()
// 0x00000083 TSource System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x00000084 System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerator.Reset()
// 0x00000085 System.Object System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerator.get_Current()
// 0x00000086 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x00000087 System.Collections.IEnumerator System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000088 System.Void System.Linq.Enumerable/<OfTypeIterator>d__97`1::.ctor(System.Int32)
// 0x00000089 System.Void System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.IDisposable.Dispose()
// 0x0000008A System.Boolean System.Linq.Enumerable/<OfTypeIterator>d__97`1::MoveNext()
// 0x0000008B System.Void System.Linq.Enumerable/<OfTypeIterator>d__97`1::<>m__Finally1()
// 0x0000008C TResult System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x0000008D System.Void System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.Collections.IEnumerator.Reset()
// 0x0000008E System.Object System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.Collections.IEnumerator.get_Current()
// 0x0000008F System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x00000090 System.Collections.IEnumerator System.Linq.Enumerable/<OfTypeIterator>d__97`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000091 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::.ctor(System.Int32)
// 0x00000092 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::System.IDisposable.Dispose()
// 0x00000093 System.Boolean System.Linq.Enumerable/<CastIterator>d__99`1::MoveNext()
// 0x00000094 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::<>m__Finally1()
// 0x00000095 TResult System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x00000096 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerator.Reset()
// 0x00000097 System.Object System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerator.get_Current()
// 0x00000098 System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x00000099 System.Collections.IEnumerator System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000009A System.Void System.Linq.EmptyEnumerable`1::.cctor()
// 0x0000009B System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000009C System.Void System.Linq.Set`1::.ctor(System.Collections.Generic.IEqualityComparer`1<TElement>)
// 0x0000009D System.Boolean System.Linq.Set`1::Add(TElement)
// 0x0000009E System.Boolean System.Linq.Set`1::Remove(TElement)
// 0x0000009F System.Boolean System.Linq.Set`1::Find(TElement,System.Boolean)
// 0x000000A0 System.Void System.Linq.Set`1::Resize()
// 0x000000A1 System.Int32 System.Linq.Set`1::InternalGetHashCode(TElement)
// 0x000000A2 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x000000A3 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x000000A4 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x000000A5 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x000000A6 System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x000000A7 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x000000A8 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x000000A9 System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x000000AA TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x000000AB System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x000000AC System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x000000AD System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x000000AE System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x000000AF System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x000000B0 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x000000B1 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x000000B2 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x000000B3 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x000000B4 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x000000B5 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x000000B6 System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x000000B7 System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x000000B8 TElement[] System.Linq.Buffer`1::ToArray()
// 0x000000B9 System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x000000BA System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x000000BB System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x000000BC System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x000000BD System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x000000BE System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x000000BF System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x000000C0 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x000000C1 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x000000C2 System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x000000C3 System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x000000C4 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x000000C5 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x000000C6 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x000000C7 System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x000000C8 System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x000000C9 System.Void System.Collections.Generic.HashSet`1::UnionWith(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000CA System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x000000CB System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x000000CC System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x000000CD System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x000000CE System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x000000CF System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x000000D0 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x000000D1 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x000000D2 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x000000D3 System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x000000D4 T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x000000D5 System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x000000D6 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[214] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	Enumerable_Sum_m6CFC8CEAC70AE3C469A5D1993FAF8EEEC6A06FB5,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[214] = 
{
	6398,
	6398,
	6621,
	6621,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	6301,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[69] = 
{
	{ 0x02000004, { 100, 4 } },
	{ 0x02000005, { 104, 9 } },
	{ 0x02000006, { 115, 7 } },
	{ 0x02000007, { 124, 10 } },
	{ 0x02000008, { 136, 11 } },
	{ 0x02000009, { 150, 9 } },
	{ 0x0200000A, { 162, 12 } },
	{ 0x0200000B, { 177, 1 } },
	{ 0x0200000C, { 178, 2 } },
	{ 0x0200000D, { 180, 12 } },
	{ 0x0200000E, { 192, 8 } },
	{ 0x0200000F, { 200, 11 } },
	{ 0x02000010, { 211, 12 } },
	{ 0x02000011, { 223, 12 } },
	{ 0x02000012, { 235, 6 } },
	{ 0x02000013, { 241, 6 } },
	{ 0x02000014, { 247, 2 } },
	{ 0x02000016, { 249, 8 } },
	{ 0x02000018, { 257, 3 } },
	{ 0x02000019, { 262, 5 } },
	{ 0x0200001A, { 267, 7 } },
	{ 0x0200001B, { 274, 3 } },
	{ 0x0200001C, { 277, 7 } },
	{ 0x0200001D, { 284, 4 } },
	{ 0x0200001E, { 288, 23 } },
	{ 0x02000020, { 311, 2 } },
	{ 0x06000005, { 0, 10 } },
	{ 0x06000006, { 10, 10 } },
	{ 0x06000007, { 20, 5 } },
	{ 0x06000008, { 25, 5 } },
	{ 0x06000009, { 30, 1 } },
	{ 0x0600000A, { 31, 2 } },
	{ 0x0600000B, { 33, 1 } },
	{ 0x0600000C, { 34, 2 } },
	{ 0x0600000D, { 36, 2 } },
	{ 0x0600000E, { 38, 2 } },
	{ 0x0600000F, { 40, 1 } },
	{ 0x06000010, { 41, 1 } },
	{ 0x06000011, { 42, 2 } },
	{ 0x06000012, { 44, 1 } },
	{ 0x06000013, { 45, 2 } },
	{ 0x06000014, { 47, 1 } },
	{ 0x06000015, { 48, 2 } },
	{ 0x06000016, { 50, 3 } },
	{ 0x06000017, { 53, 2 } },
	{ 0x06000018, { 55, 1 } },
	{ 0x06000019, { 56, 2 } },
	{ 0x0600001A, { 58, 2 } },
	{ 0x0600001B, { 60, 2 } },
	{ 0x0600001C, { 62, 4 } },
	{ 0x0600001D, { 66, 4 } },
	{ 0x0600001E, { 70, 4 } },
	{ 0x0600001F, { 74, 3 } },
	{ 0x06000020, { 77, 3 } },
	{ 0x06000021, { 80, 1 } },
	{ 0x06000022, { 81, 1 } },
	{ 0x06000023, { 82, 3 } },
	{ 0x06000024, { 85, 3 } },
	{ 0x06000025, { 88, 2 } },
	{ 0x06000026, { 90, 2 } },
	{ 0x06000027, { 92, 5 } },
	{ 0x06000028, { 97, 3 } },
	{ 0x06000039, { 113, 2 } },
	{ 0x0600003E, { 122, 2 } },
	{ 0x06000043, { 134, 2 } },
	{ 0x06000049, { 147, 3 } },
	{ 0x0600004E, { 159, 3 } },
	{ 0x06000053, { 174, 3 } },
	{ 0x060000A5, { 260, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[313] = 
{
	{ (Il2CppRGCTXDataType)2, 6662 },
	{ (Il2CppRGCTXDataType)3, 25492 },
	{ (Il2CppRGCTXDataType)2, 10503 },
	{ (Il2CppRGCTXDataType)2, 9786 },
	{ (Il2CppRGCTXDataType)3, 43868 },
	{ (Il2CppRGCTXDataType)2, 7323 },
	{ (Il2CppRGCTXDataType)2, 9820 },
	{ (Il2CppRGCTXDataType)3, 43912 },
	{ (Il2CppRGCTXDataType)2, 9801 },
	{ (Il2CppRGCTXDataType)3, 43884 },
	{ (Il2CppRGCTXDataType)2, 6663 },
	{ (Il2CppRGCTXDataType)3, 25493 },
	{ (Il2CppRGCTXDataType)2, 10534 },
	{ (Il2CppRGCTXDataType)2, 9835 },
	{ (Il2CppRGCTXDataType)3, 43928 },
	{ (Il2CppRGCTXDataType)2, 7349 },
	{ (Il2CppRGCTXDataType)2, 9863 },
	{ (Il2CppRGCTXDataType)3, 44070 },
	{ (Il2CppRGCTXDataType)2, 9849 },
	{ (Il2CppRGCTXDataType)3, 43993 },
	{ (Il2CppRGCTXDataType)2, 1167 },
	{ (Il2CppRGCTXDataType)3, 161 },
	{ (Il2CppRGCTXDataType)3, 162 },
	{ (Il2CppRGCTXDataType)2, 3763 },
	{ (Il2CppRGCTXDataType)3, 15879 },
	{ (Il2CppRGCTXDataType)2, 1168 },
	{ (Il2CppRGCTXDataType)3, 171 },
	{ (Il2CppRGCTXDataType)3, 172 },
	{ (Il2CppRGCTXDataType)2, 3778 },
	{ (Il2CppRGCTXDataType)3, 15886 },
	{ (Il2CppRGCTXDataType)3, 49021 },
	{ (Il2CppRGCTXDataType)2, 1211 },
	{ (Il2CppRGCTXDataType)3, 362 },
	{ (Il2CppRGCTXDataType)3, 49027 },
	{ (Il2CppRGCTXDataType)2, 1219 },
	{ (Il2CppRGCTXDataType)3, 398 },
	{ (Il2CppRGCTXDataType)2, 7992 },
	{ (Il2CppRGCTXDataType)3, 34615 },
	{ (Il2CppRGCTXDataType)2, 7993 },
	{ (Il2CppRGCTXDataType)3, 34616 },
	{ (Il2CppRGCTXDataType)3, 20888 },
	{ (Il2CppRGCTXDataType)3, 48959 },
	{ (Il2CppRGCTXDataType)2, 1174 },
	{ (Il2CppRGCTXDataType)3, 228 },
	{ (Il2CppRGCTXDataType)3, 49066 },
	{ (Il2CppRGCTXDataType)2, 1222 },
	{ (Il2CppRGCTXDataType)3, 421 },
	{ (Il2CppRGCTXDataType)3, 48977 },
	{ (Il2CppRGCTXDataType)2, 1200 },
	{ (Il2CppRGCTXDataType)3, 320 },
	{ (Il2CppRGCTXDataType)2, 1543 },
	{ (Il2CppRGCTXDataType)3, 2947 },
	{ (Il2CppRGCTXDataType)3, 2948 },
	{ (Il2CppRGCTXDataType)2, 7324 },
	{ (Il2CppRGCTXDataType)3, 27604 },
	{ (Il2CppRGCTXDataType)3, 48984 },
	{ (Il2CppRGCTXDataType)2, 1203 },
	{ (Il2CppRGCTXDataType)3, 334 },
	{ (Il2CppRGCTXDataType)2, 4285 },
	{ (Il2CppRGCTXDataType)3, 48899 },
	{ (Il2CppRGCTXDataType)2, 1171 },
	{ (Il2CppRGCTXDataType)3, 214 },
	{ (Il2CppRGCTXDataType)2, 5737 },
	{ (Il2CppRGCTXDataType)2, 4055 },
	{ (Il2CppRGCTXDataType)2, 4302 },
	{ (Il2CppRGCTXDataType)2, 4626 },
	{ (Il2CppRGCTXDataType)2, 5738 },
	{ (Il2CppRGCTXDataType)2, 4056 },
	{ (Il2CppRGCTXDataType)2, 4303 },
	{ (Il2CppRGCTXDataType)2, 4627 },
	{ (Il2CppRGCTXDataType)2, 5739 },
	{ (Il2CppRGCTXDataType)2, 4057 },
	{ (Il2CppRGCTXDataType)2, 4304 },
	{ (Il2CppRGCTXDataType)2, 4628 },
	{ (Il2CppRGCTXDataType)2, 4305 },
	{ (Il2CppRGCTXDataType)2, 4629 },
	{ (Il2CppRGCTXDataType)3, 15880 },
	{ (Il2CppRGCTXDataType)2, 5736 },
	{ (Il2CppRGCTXDataType)2, 4301 },
	{ (Il2CppRGCTXDataType)2, 4625 },
	{ (Il2CppRGCTXDataType)2, 2628 },
	{ (Il2CppRGCTXDataType)2, 4281 },
	{ (Il2CppRGCTXDataType)2, 4282 },
	{ (Il2CppRGCTXDataType)2, 4623 },
	{ (Il2CppRGCTXDataType)3, 15878 },
	{ (Il2CppRGCTXDataType)2, 4280 },
	{ (Il2CppRGCTXDataType)2, 4622 },
	{ (Il2CppRGCTXDataType)3, 15877 },
	{ (Il2CppRGCTXDataType)2, 4054 },
	{ (Il2CppRGCTXDataType)2, 4300 },
	{ (Il2CppRGCTXDataType)2, 4053 },
	{ (Il2CppRGCTXDataType)3, 48937 },
	{ (Il2CppRGCTXDataType)3, 14696 },
	{ (Il2CppRGCTXDataType)2, 3567 },
	{ (Il2CppRGCTXDataType)2, 4284 },
	{ (Il2CppRGCTXDataType)2, 4624 },
	{ (Il2CppRGCTXDataType)2, 4867 },
	{ (Il2CppRGCTXDataType)2, 4331 },
	{ (Il2CppRGCTXDataType)2, 4635 },
	{ (Il2CppRGCTXDataType)3, 16109 },
	{ (Il2CppRGCTXDataType)3, 25494 },
	{ (Il2CppRGCTXDataType)3, 25496 },
	{ (Il2CppRGCTXDataType)2, 855 },
	{ (Il2CppRGCTXDataType)3, 25495 },
	{ (Il2CppRGCTXDataType)3, 25504 },
	{ (Il2CppRGCTXDataType)2, 6666 },
	{ (Il2CppRGCTXDataType)2, 9802 },
	{ (Il2CppRGCTXDataType)3, 43885 },
	{ (Il2CppRGCTXDataType)3, 25505 },
	{ (Il2CppRGCTXDataType)2, 4394 },
	{ (Il2CppRGCTXDataType)2, 4683 },
	{ (Il2CppRGCTXDataType)3, 15894 },
	{ (Il2CppRGCTXDataType)3, 48902 },
	{ (Il2CppRGCTXDataType)2, 9850 },
	{ (Il2CppRGCTXDataType)3, 43994 },
	{ (Il2CppRGCTXDataType)3, 25497 },
	{ (Il2CppRGCTXDataType)2, 6665 },
	{ (Il2CppRGCTXDataType)2, 9787 },
	{ (Il2CppRGCTXDataType)3, 43869 },
	{ (Il2CppRGCTXDataType)3, 15893 },
	{ (Il2CppRGCTXDataType)3, 25498 },
	{ (Il2CppRGCTXDataType)3, 48901 },
	{ (Il2CppRGCTXDataType)2, 9836 },
	{ (Il2CppRGCTXDataType)3, 43929 },
	{ (Il2CppRGCTXDataType)3, 25511 },
	{ (Il2CppRGCTXDataType)2, 6667 },
	{ (Il2CppRGCTXDataType)2, 9821 },
	{ (Il2CppRGCTXDataType)3, 43913 },
	{ (Il2CppRGCTXDataType)3, 27665 },
	{ (Il2CppRGCTXDataType)3, 12751 },
	{ (Il2CppRGCTXDataType)3, 15895 },
	{ (Il2CppRGCTXDataType)3, 12750 },
	{ (Il2CppRGCTXDataType)3, 25512 },
	{ (Il2CppRGCTXDataType)3, 48903 },
	{ (Il2CppRGCTXDataType)2, 9864 },
	{ (Il2CppRGCTXDataType)3, 44071 },
	{ (Il2CppRGCTXDataType)3, 25525 },
	{ (Il2CppRGCTXDataType)2, 6669 },
	{ (Il2CppRGCTXDataType)2, 9852 },
	{ (Il2CppRGCTXDataType)3, 43996 },
	{ (Il2CppRGCTXDataType)3, 25526 },
	{ (Il2CppRGCTXDataType)2, 4397 },
	{ (Il2CppRGCTXDataType)2, 4686 },
	{ (Il2CppRGCTXDataType)3, 15899 },
	{ (Il2CppRGCTXDataType)3, 15898 },
	{ (Il2CppRGCTXDataType)2, 9804 },
	{ (Il2CppRGCTXDataType)3, 43887 },
	{ (Il2CppRGCTXDataType)3, 48909 },
	{ (Il2CppRGCTXDataType)2, 9851 },
	{ (Il2CppRGCTXDataType)3, 43995 },
	{ (Il2CppRGCTXDataType)3, 25518 },
	{ (Il2CppRGCTXDataType)2, 6668 },
	{ (Il2CppRGCTXDataType)2, 9838 },
	{ (Il2CppRGCTXDataType)3, 43931 },
	{ (Il2CppRGCTXDataType)3, 15897 },
	{ (Il2CppRGCTXDataType)3, 15896 },
	{ (Il2CppRGCTXDataType)3, 25519 },
	{ (Il2CppRGCTXDataType)2, 9803 },
	{ (Il2CppRGCTXDataType)3, 43886 },
	{ (Il2CppRGCTXDataType)3, 48908 },
	{ (Il2CppRGCTXDataType)2, 9837 },
	{ (Il2CppRGCTXDataType)3, 43930 },
	{ (Il2CppRGCTXDataType)3, 25532 },
	{ (Il2CppRGCTXDataType)2, 6670 },
	{ (Il2CppRGCTXDataType)2, 9866 },
	{ (Il2CppRGCTXDataType)3, 44073 },
	{ (Il2CppRGCTXDataType)3, 27666 },
	{ (Il2CppRGCTXDataType)3, 12753 },
	{ (Il2CppRGCTXDataType)3, 15901 },
	{ (Il2CppRGCTXDataType)3, 15900 },
	{ (Il2CppRGCTXDataType)3, 12752 },
	{ (Il2CppRGCTXDataType)3, 25533 },
	{ (Il2CppRGCTXDataType)2, 9805 },
	{ (Il2CppRGCTXDataType)3, 43888 },
	{ (Il2CppRGCTXDataType)3, 48910 },
	{ (Il2CppRGCTXDataType)2, 9865 },
	{ (Il2CppRGCTXDataType)3, 44072 },
	{ (Il2CppRGCTXDataType)3, 15890 },
	{ (Il2CppRGCTXDataType)3, 15891 },
	{ (Il2CppRGCTXDataType)3, 15902 },
	{ (Il2CppRGCTXDataType)3, 365 },
	{ (Il2CppRGCTXDataType)3, 364 },
	{ (Il2CppRGCTXDataType)2, 4383 },
	{ (Il2CppRGCTXDataType)2, 4675 },
	{ (Il2CppRGCTXDataType)3, 15892 },
	{ (Il2CppRGCTXDataType)2, 4420 },
	{ (Il2CppRGCTXDataType)2, 4715 },
	{ (Il2CppRGCTXDataType)3, 367 },
	{ (Il2CppRGCTXDataType)2, 1077 },
	{ (Il2CppRGCTXDataType)2, 1212 },
	{ (Il2CppRGCTXDataType)3, 363 },
	{ (Il2CppRGCTXDataType)3, 366 },
	{ (Il2CppRGCTXDataType)3, 400 },
	{ (Il2CppRGCTXDataType)2, 4386 },
	{ (Il2CppRGCTXDataType)2, 4677 },
	{ (Il2CppRGCTXDataType)3, 402 },
	{ (Il2CppRGCTXDataType)2, 851 },
	{ (Il2CppRGCTXDataType)2, 1220 },
	{ (Il2CppRGCTXDataType)3, 399 },
	{ (Il2CppRGCTXDataType)3, 401 },
	{ (Il2CppRGCTXDataType)3, 230 },
	{ (Il2CppRGCTXDataType)2, 9051 },
	{ (Il2CppRGCTXDataType)3, 40044 },
	{ (Il2CppRGCTXDataType)2, 4376 },
	{ (Il2CppRGCTXDataType)2, 4670 },
	{ (Il2CppRGCTXDataType)3, 40045 },
	{ (Il2CppRGCTXDataType)3, 232 },
	{ (Il2CppRGCTXDataType)2, 844 },
	{ (Il2CppRGCTXDataType)2, 1175 },
	{ (Il2CppRGCTXDataType)3, 229 },
	{ (Il2CppRGCTXDataType)3, 231 },
	{ (Il2CppRGCTXDataType)3, 423 },
	{ (Il2CppRGCTXDataType)3, 424 },
	{ (Il2CppRGCTXDataType)2, 9055 },
	{ (Il2CppRGCTXDataType)3, 40049 },
	{ (Il2CppRGCTXDataType)2, 4389 },
	{ (Il2CppRGCTXDataType)2, 4679 },
	{ (Il2CppRGCTXDataType)3, 40050 },
	{ (Il2CppRGCTXDataType)3, 426 },
	{ (Il2CppRGCTXDataType)2, 853 },
	{ (Il2CppRGCTXDataType)2, 1223 },
	{ (Il2CppRGCTXDataType)3, 422 },
	{ (Il2CppRGCTXDataType)3, 425 },
	{ (Il2CppRGCTXDataType)3, 322 },
	{ (Il2CppRGCTXDataType)2, 9053 },
	{ (Il2CppRGCTXDataType)3, 40046 },
	{ (Il2CppRGCTXDataType)2, 4379 },
	{ (Il2CppRGCTXDataType)2, 4672 },
	{ (Il2CppRGCTXDataType)3, 40047 },
	{ (Il2CppRGCTXDataType)3, 40048 },
	{ (Il2CppRGCTXDataType)3, 324 },
	{ (Il2CppRGCTXDataType)2, 846 },
	{ (Il2CppRGCTXDataType)2, 1201 },
	{ (Il2CppRGCTXDataType)3, 321 },
	{ (Il2CppRGCTXDataType)3, 323 },
	{ (Il2CppRGCTXDataType)3, 336 },
	{ (Il2CppRGCTXDataType)2, 848 },
	{ (Il2CppRGCTXDataType)3, 338 },
	{ (Il2CppRGCTXDataType)2, 1204 },
	{ (Il2CppRGCTXDataType)3, 335 },
	{ (Il2CppRGCTXDataType)3, 337 },
	{ (Il2CppRGCTXDataType)3, 216 },
	{ (Il2CppRGCTXDataType)2, 842 },
	{ (Il2CppRGCTXDataType)3, 218 },
	{ (Il2CppRGCTXDataType)2, 1172 },
	{ (Il2CppRGCTXDataType)3, 215 },
	{ (Il2CppRGCTXDataType)3, 217 },
	{ (Il2CppRGCTXDataType)2, 10549 },
	{ (Il2CppRGCTXDataType)2, 2629 },
	{ (Il2CppRGCTXDataType)3, 14736 },
	{ (Il2CppRGCTXDataType)2, 3583 },
	{ (Il2CppRGCTXDataType)2, 10973 },
	{ (Il2CppRGCTXDataType)3, 40041 },
	{ (Il2CppRGCTXDataType)3, 40042 },
	{ (Il2CppRGCTXDataType)2, 4884 },
	{ (Il2CppRGCTXDataType)3, 40043 },
	{ (Il2CppRGCTXDataType)2, 756 },
	{ (Il2CppRGCTXDataType)2, 1177 },
	{ (Il2CppRGCTXDataType)3, 242 },
	{ (Il2CppRGCTXDataType)3, 34590 },
	{ (Il2CppRGCTXDataType)2, 7994 },
	{ (Il2CppRGCTXDataType)3, 34617 },
	{ (Il2CppRGCTXDataType)2, 1544 },
	{ (Il2CppRGCTXDataType)3, 2949 },
	{ (Il2CppRGCTXDataType)3, 34596 },
	{ (Il2CppRGCTXDataType)3, 12693 },
	{ (Il2CppRGCTXDataType)2, 885 },
	{ (Il2CppRGCTXDataType)3, 34591 },
	{ (Il2CppRGCTXDataType)2, 7989 },
	{ (Il2CppRGCTXDataType)3, 3376 },
	{ (Il2CppRGCTXDataType)2, 1566 },
	{ (Il2CppRGCTXDataType)2, 2812 },
	{ (Il2CppRGCTXDataType)3, 12711 },
	{ (Il2CppRGCTXDataType)3, 34592 },
	{ (Il2CppRGCTXDataType)3, 12688 },
	{ (Il2CppRGCTXDataType)3, 12689 },
	{ (Il2CppRGCTXDataType)3, 12687 },
	{ (Il2CppRGCTXDataType)3, 12690 },
	{ (Il2CppRGCTXDataType)2, 2808 },
	{ (Il2CppRGCTXDataType)2, 10607 },
	{ (Il2CppRGCTXDataType)3, 15888 },
	{ (Il2CppRGCTXDataType)3, 12692 },
	{ (Il2CppRGCTXDataType)2, 4211 },
	{ (Il2CppRGCTXDataType)3, 12691 },
	{ (Il2CppRGCTXDataType)2, 4062 },
	{ (Il2CppRGCTXDataType)2, 10543 },
	{ (Il2CppRGCTXDataType)2, 4334 },
	{ (Il2CppRGCTXDataType)2, 4637 },
	{ (Il2CppRGCTXDataType)3, 14715 },
	{ (Il2CppRGCTXDataType)2, 3576 },
	{ (Il2CppRGCTXDataType)3, 16773 },
	{ (Il2CppRGCTXDataType)3, 16774 },
	{ (Il2CppRGCTXDataType)3, 16779 },
	{ (Il2CppRGCTXDataType)2, 4878 },
	{ (Il2CppRGCTXDataType)3, 16776 },
	{ (Il2CppRGCTXDataType)3, 50076 },
	{ (Il2CppRGCTXDataType)2, 2816 },
	{ (Il2CppRGCTXDataType)3, 12741 },
	{ (Il2CppRGCTXDataType)1, 4202 },
	{ (Il2CppRGCTXDataType)2, 10555 },
	{ (Il2CppRGCTXDataType)3, 16775 },
	{ (Il2CppRGCTXDataType)1, 10555 },
	{ (Il2CppRGCTXDataType)1, 4878 },
	{ (Il2CppRGCTXDataType)2, 10971 },
	{ (Il2CppRGCTXDataType)2, 10555 },
	{ (Il2CppRGCTXDataType)2, 4340 },
	{ (Il2CppRGCTXDataType)2, 4641 },
	{ (Il2CppRGCTXDataType)3, 16780 },
	{ (Il2CppRGCTXDataType)3, 16778 },
	{ (Il2CppRGCTXDataType)3, 16777 },
	{ (Il2CppRGCTXDataType)2, 644 },
	{ (Il2CppRGCTXDataType)3, 12754 },
	{ (Il2CppRGCTXDataType)2, 864 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	214,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	69,
	s_rgctxIndices,
	313,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
