import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
// import HomeMonitoringSys from 'src/views/monitoring-system'
// import Error401 from '../401'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'

const WaterResourcePage = () => {
  const { hasPermission } = useRequireAuth()
  const router = useRouter()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(router.pathname, 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, router.pathname])

  if (hasAccess === null) {
    return <BoxLoading />
  }

  // return hasAccess ? <HomeMonitoringSys /> : <Error401 />
}

export default WaterResourcePage
