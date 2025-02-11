import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import ManageLicense from 'src/views/license/manage'
import Error401 from 'src/pages/401'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'

const ManageLicensePage = () => {
  const { hasPermission } = useRequireAuth()
  const router = useRouter()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(router.pathname.split('/')[2], 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, router.pathname])

  if (hasAccess === null) {
    return <BoxLoading />
  }

  return hasAccess ? <ManageLicense /> : <Error401 />
}

export default ManageLicensePage
