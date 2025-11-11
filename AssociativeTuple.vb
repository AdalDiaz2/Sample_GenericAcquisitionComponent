Imports System.Collections.Generic

Public Class AssociativeTuple(Of T1, T2)
    Private m_AssociativeTupleDictionary As Dictionary(Of T1, T2) = New Dictionary(Of T1, T2)()

    Public Sub New()
    End Sub

    Default Public Property Item(i_x_Type1 As T1) As T2
        Get
            If Not m_AssociativeTupleDictionary.ContainsKey(i_x_Type1) Then Throw New KeyNotFoundException("The given key is not part of this associative tuple: " & i_x_Type1.ToString())

            Return m_AssociativeTupleDictionary(i_x_Type1)
        End Get

        Set(value As T2)
            m_AssociativeTupleDictionary(i_x_Type1) = value
        End Set
    End Property

    Default Public Property Item(i_x_Type2 As T2) As T1
        Get
            If Not m_AssociativeTupleDictionary.ContainsValue(i_x_Type2) Then Throw New KeyNotFoundException("The given key is not part of this associative tuple: " & i_x_Type2.ToString())

            Dim l_x_Type1 As T1 = Nothing

            For Each l_x_KeyValuePair In m_AssociativeTupleDictionary
                If l_x_KeyValuePair.Value.Equals(i_x_Type2) Then
                    l_x_Type1 = l_x_KeyValuePair.Key
                    Exit For
                End If
            Next

            Return l_x_Type1
        End Get

        Set(value As T1)
            Try
                Dim l_x_Type1 = Me(i_x_Type2)

                If Not l_x_Type1.Equals(value) Then
                    m_AssociativeTupleDictionary.Remove(l_x_Type1)
                    m_AssociativeTupleDictionary(value) = i_x_Type2
                End If
            Catch __unusedKeyNotFoundException1__ As KeyNotFoundException
                m_AssociativeTupleDictionary(value) = i_x_Type2
            End Try
        End Set
    End Property

    Public Function Contains(i_x_Type1 As T1) As Boolean
        Return m_AssociativeTupleDictionary.ContainsKey(i_x_Type1)
    End Function

    Public Function Contains(i_x_Type2 As T2) As Boolean
        Return m_AssociativeTupleDictionary.ContainsValue(i_x_Type2)
    End Function

    Public ReadOnly Property Firsts As T1()
        Get
            Dim l_x_Type1Array = New T1(m_AssociativeTupleDictionary.Keys.Count - 1) {}

            m_AssociativeTupleDictionary.Keys.CopyTo(l_x_Type1Array, 0)

            Return l_x_Type1Array
        End Get
    End Property

    Public ReadOnly Property Seconds As T2()
        Get
            Dim l_x_Type2Array = New T2(m_AssociativeTupleDictionary.Values.Count - 1) {}

            m_AssociativeTupleDictionary.Values.CopyTo(l_x_Type2Array, 0)

            Return l_x_Type2Array
        End Get
    End Property
End Class