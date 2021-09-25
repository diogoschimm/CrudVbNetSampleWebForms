Public MustInherit Class RepositoryBase

    Protected ReadOnly Options As IOptions

    Protected Sub New(options As IOptions)
        Me.Options = options
    End Sub

End Class
