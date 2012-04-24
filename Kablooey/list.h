#pragma once

#include <iostream>

template <class T>
class ListNode
{
	template <class> friend class List;

public:
	ListNode();
	ListNode(T data);
	~ListNode();

	ListNode<T>*& getNext();
	ListNode<T>*& getPrev();
	void setNext(ListNode<T>* pNext);
	void setPrev(ListNode<T>* pPrev);
	T& getData();

private:
	T data;
	ListNode<T>* pNext;
	ListNode<T>* pPrev;
};

template <class T>
class List
{
public:
	List();
	~List();

	bool isEmpty();
	ListNode<T>* searchList(T data);
	bool remove(T data);
	T insert(T data);
	void setFirst(ListNode<T>* pFirst);
	ListNode<T>* getFirst();

	int getSize();
private:
	ListNode<T>* pFirst;
	int size;
};

template <class T>
List<T>::List()
{
	this->pFirst = NULL;
	this->size = 0;
}

template <class T>
List<T>::~List()
{
	if (!this->isEmpty())
	{
		while (this->pFirst->pNext != NULL)
		{
			this->pFirst = this->pFirst->pNext;
			delete(this->pFirst->pPrev);
		}

		delete(this->pFirst);
	}
}

template <class T>
bool List<T>::isEmpty()
{
	return (this->pFirst == NULL)? true:false;
}

template <class T>
void List<T>::setFirst(ListNode<T>* pFirst)
{
	this->pFirst = pFirst;
}

template <class T>
int List<T>::getSize()
{
	return this->size;
}

template <class T>
ListNode<T>* List<T>::searchList(T data)
{
	ListNode<T>* pTemp = this->pFirst;

	while (pTemp != NULL)
	{
		if (pTemp->data == data)
			return pTemp;

		pTemp = pTemp->pNext;
	}

return NULL;
}

template <class T>
bool List<T>::remove(T data)
{
	if (!this->isEmpty())
	{ ListNode<T>* pTemp;
		if ((pTemp = this->searchList(data)) != NULL)
		{
			if (pTemp->pNext != NULL)
				pTemp->pNext->pPrev = pTemp->pPrev;
			
			if (pTemp->pPrev != NULL)
				pTemp->pPrev->pNext = pTemp->pNext;

			if (pTemp == this->pFirst)
				this->pFirst = this->pFirst->getNext();

			delete(pTemp);

			this->size--;
			return true;
		}
	}
return false;
}

template <class T>
T List<T>::insert(T data)
{
		ListNode<T>* pMem = new ListNode<T>(data);
		pMem->pNext = this->pFirst;

		if (! ( this->isEmpty() ) )
			this->pFirst->pPrev = pMem;

		this->pFirst = pMem;

		this->size++;

return data;
}

template <class T>
ListNode<T>* List<T>::getFirst()
{
	return this->pFirst;
}

template <class T>
ListNode<T>::ListNode()
{
	this->pNext = NULL;
	this->pPrev = NULL;
}

template <class T>
ListNode<T>::ListNode(T data)
{
	this->data = data;
	this->pNext = NULL;
	this->pPrev = NULL;
}

template <class T>
ListNode<T>::~ListNode()
{
}

template <class T>
ListNode<T>*& ListNode<T>::getNext()
{
	return this->pNext;
}

template <class T>
ListNode<T>*& ListNode<T>::getPrev()
{
	return this->pPrev;
}

template <class T>
void ListNode<T>::setNext(ListNode<T>* pNext)
{
	this->pNext = pNext;
}

template <class T>
void ListNode<T>::setPrev(ListNode<T>* pPrev)
{
	this->pPrev = pPrev;
}

template <class T>
T& ListNode<T>::getData()
{
	return this->data;
}
