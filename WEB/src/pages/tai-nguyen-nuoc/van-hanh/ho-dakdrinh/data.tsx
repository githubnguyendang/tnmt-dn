import { useState, useEffect } from 'react'

// Định nghĩa dữ liệu thời tiết từ Windy API cho Đăkđrinh
const windyDataDakto = {
  ts: [
    // Thời gian dự báo
    1732590000000, 1732600800000, 1732611600000, 1732622400000, 1732633200000, 1732644000000, 1732654800000,
    1732665600000, 1732676400000, 1732687200000, 1732698000000, 1732708800000, 1732719600000, 1732730400000,
    1732741200000, 1732752000000, 1732762800000, 1732773600000, 1732784400000, 1732795200000, 1732806000000,
    1732816800000, 1732827600000, 1732838400000, 1732849200000, 1732860000000, 1732870800000, 1732881600000,
    1732892400000, 1732903200000, 1732914000000, 1732924800000, 1732935600000, 1732946400000, 1732957200000,
    1732968000000, 1732978800000, 1732989600000, 1733000400000, 1733011200000, 1733022000000, 1733032800000,
    1733043600000, 1733054400000, 1733065200000, 1733076000000, 1733086800000, 1733097600000, 1733108400000,
    1733119200000, 1733130000000, 1733140800000, 1733151600000, 1733162400000, 1733173200000, 1733184000000,
    1733194800000, 1733205600000, 1733216400000, 1733227200000, 1733238000000, 1733248800000, 1733259600000,
    1733270400000, 1733281200000, 1733292000000, 1733302800000, 1733313600000, 1733324400000, 1733335200000,
    1733346000000, 1733356800000, 1733367600000, 1733378400000, 1733389200000, 1733400000000, 1733410800000,
    1733421600000, 1733432400000, 1733443200000
  ],
  units: {
    'past3hprecip-surface': 'm'
  },
  'past3hprecip-surface': [
    // Dữ liệu mưa trong 3 giờ gần nhất
    0.000014110831019017721, 0, 0.000014110831019017721, 0, 0, 0, 0, 0, 0.000014110831019017721, 0, 0,
    0.000014110831019017721, 0.00002204817346721566, 0.00001411083101901772, 0, 0.000014110831019017721,
    0.00011103371074559022, 0.00007663856013673499, 0, 0.00002950446485794614, 0.00025599042939543587, 0, 0,
    0.000014110831019017721, 0.000028221662038035442, 0, 0.000053307583849608643, 0, 0, 0, 0, 0.000028221662038035442,
    0.000014110831019017721, 0, 0.00012994614398633664, 0, 0.00006124492629780656, 0, 0, 0, 0, 0, 0,
    0.00004713409527878189, 0.00010347942747274807, 0.000007937342448197939, 0.000014110831019017721,
    0.00007839350566118184, 0.000014110831019017721, 0, 0, 0.000014110831019017721, 0.000025085921811573194,
    0.000014110831019017721, 0.000050269835505244135, 0, 0, 0, 0.000014110831019017721, 0, 0, 0.000028221662038035442,
    0, 0.000014110831019017721, 0.00003615900448623338, 0.000042332493057053154, 0.00018415347148044352, 0,
    0.000014110831019017721, 0.000039196752830590905, 0, 0.00010486022217477044, 0, 0, 0.000028221662038035442,
    0.000014110831019017721, 0, 0, 0, 0.00003919675283058395
  ],
  warning:
    'The trial API version is for development purposes only. This data is randomly shuffled and slightly modified.'
}

// Định nghĩa dữ liệu thời tiết từ Windy API cho Quảng Ngãi
const windyDataQuangNgai = {
  ts: [
    // Thời gian dự báo
    1732590000000, 1732600800000, 1732611600000, 1732622400000, 1732633200000, 1732644000000, 1732654800000,
    1732665600000, 1732676400000, 1732687200000, 1732698000000, 1732708800000, 1732719600000, 1732730400000,
    1732741200000, 1732752000000, 1732762800000, 1732773600000, 1732784400000, 1732795200000, 1732806000000,
    1732816800000, 1732827600000, 1732838400000, 1732849200000, 1732860000000, 1732870800000, 1732881600000,
    1732892400000, 1732903200000, 1732914000000, 1732924800000, 1732935600000, 1732946400000, 1732957200000,
    1732968000000, 1732978800000, 1732989600000, 1733000400000, 1733011200000, 1733022000000, 1733032800000,
    1733043600000, 1733054400000, 1733065200000, 1733076000000, 1733086800000, 1733097600000, 1733108400000,
    1733119200000, 1733130000000, 1733140800000, 1733151600000, 1733162400000, 1733173200000, 1733184000000,
    1733194800000, 1733205600000, 1733216400000, 1733227200000, 1733238000000, 1733248800000, 1733259600000,
    1733270400000, 1733281200000, 1733292000000, 1733302800000, 1733313600000, 1733324400000, 1733335200000,
    1733346000000, 1733356800000, 1733367600000, 1733378400000, 1733389200000, 1733400000000, 1733410800000,
    1733421600000, 1733432400000, 1733443200000
  ],
  units: {
    'past3hprecip-surface': 'm'
  },
  'past3hprecip-surface': [
    // Dữ liệu mưa trong 3 giờ gần nhất
    0.0017877371715445478, 0.0001554329416791351, 0.0001967766075624849, 0.0027682706686605264, 0.0005857776543473536,
    0.00008241117282632075, 0.002406671715445421, 0.002915009057893548, 0.005511776116214505, 0.0028353594744712583,
    0.0012430448408459686, 0.0009415327280495589, 0.0005240071352275306, 0.0005498948088015401, 0.006382309271523214,
    0.0006518865413373145, 0.0017828197607349303, 0.00012662332834864853, 0.0030546207647938295, 0.00017718713950011465,
    0.0016888544541764838, 0.0024405056398205125, 0.0025490717368083955, 0.003028554924161492, 0.00015841723990600644,
    0.0034479334543900757, 0.001503721063875244, 0.00028985998718223884, 0.004708518842127732, 0.00009470469985045857,
    0.00347607494125179, 0.0015261790215765761, 0.00234391236915187, 0.0031658860927152284, 0.005886381264687029,
    0.0007166502670369633, 0.0008529569750053336, 0.002939177419354821, 0.004863043131809445, 0.0017652168553727817,
    0.003233242149113409, 0.001309706045716744, 0.0012146628284554885, 0.003152523563341163, 0.0034001935911130068,
    0.00014728179876094687, 0.002353613565477452, 0.0019031983336893984, 0.00006590399487289373, 0.004643764024780953,
    0.0004785834437086234, 0.0009119124546037018, 0.001036905554368719, 0.0066705033967101035, 0.00023643659474471167,
    0.002275264601580866, 0.000028809613330486565, 0.0011399217474898525, 0.00010347942747276562, 0.0006984415936765746,
    0.0008859000640888927, 0.00012976797692800969, 0.0005558010467848834, 0.004032838090151697, 0.0016211866054262078,
    0.0009330876094851512, 0.0012065562273018398, 0.002879010403759834, 0.000029451014740441747, 0.0011099451399273548,
    0.0006848474471266888, 0.003739067336039316, 0.0011965165135654752, 0.0035474308481093196, 0.0005699920529801333,
    0.0005716222815637644, 0.00616290544755389, 0.00243777077547536, 0.0009771928647724737, 0.0006094293313394565
  ],
  warning:
    'The trial API version is for development purposes only. This data is randomly shuffled and slightly modified.'
}

// Hàm xử lý dữ liệu mưa
function processData(rainForecastValue: number[]) {
  return rainForecastValue.map(
    value => (value !== null ? (value * 1000).toFixed(2) : '0') // Chuyển đổi đơn vị và xử lý từng giá trị
  )
}

// Hàm điền dữ liệu thiếu
function fillMissingData(ts: number[], precip: number[]) {
  const filledTs: number[] = []
  const filledPrecip: number[] = []

  ts.forEach((timestamp, index) => {
    const date = new Date(timestamp)
    for (let hour = 0; hour < 24; hour++) {
      const newDate = new Date(date)
      newDate.setUTCHours(hour, 0, 0, 0)
      const newTimestamp = newDate.getTime()

      // Only add the timestamp if it doesn't already exist
      if (!filledTs.includes(newTimestamp)) {
        filledTs.push(newTimestamp)

        // Add the existing precip data for the hours that are multiples of 3
        // Otherwise, add 0 for missing hours

        if (newDate.getHours() % 3 === 0 && index < precip.length) {
          console.log(precip[index])

          filledPrecip.push(precip[index])
        } else {
          filledPrecip.push(0)
        }
      }
    }
  })

  console.log(filledPrecip)

  return { filledTs, filledPrecip }
}

// Điền dữ liệu thiếu cho Đăkđrinh
const { filledTs: filledTsDakto, filledPrecip: filledPrecipDakto } = fillMissingData(
  windyDataDakto.ts,
  windyDataDakto['past3hprecip-surface']
)

// Điền dữ liệu thiếu cho Quảng Ngãi
const { filledTs: filledTsQuangNgai, filledPrecip: filledPrecipQuangNgai } = fillMissingData(
  windyDataQuangNgai.ts,
  windyDataQuangNgai['past3hprecip-surface']
)

// Cập nhật đối tượng dữ liệu với dữ liệu đã điền thiếu
windyDataDakto.ts = filledTsDakto
windyDataQuangNgai.ts = filledTsQuangNgai

// Custom hook để sử dụng dữ liệu đã xử lý
export default function useRainData() {
  const [xDakTo, setXDakTo] = useState<string[]>([])
  const [xQuangNgai, setXquangNgai] = useState<string[]>([])
  const [dateTime, setDateTime] = useState<string[]>([]) // State cho dateTime

  useEffect(() => {
    const processedDakTo = processData(filledPrecipDakto)
    const processedQuangNgai = processData(filledPrecipQuangNgai)
    const xQuangNgai22to25 = [
      0, 58, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25.1, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0,
      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    ]
    const xDakTo22to25 = [
      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    ]

    const startDate = new Date('22-11-2024 00:00')
    const endDate = new Date(startDate)
    endDate.setDate(startDate.getDate() + 3) // Add 3 days to the start date

    const dateArray = []
    while (startDate <= endDate) {
      dateArray.push(startDate.toISOString().split('T')[0])
      startDate.setHours(startDate.getHours() + 1)
    }

    const dateArrayStrings = dateArray.map(num => num.toString())

    console.log(dateArray)

    // Convert xQuangNgai22to25 numbers to strings
    const xQuangNgai22to25Strings = xQuangNgai22to25.map(num => num.toString())
    setXquangNgai([...xQuangNgai22to25Strings, ...processedQuangNgai])

    // Convert xDakto22to25 numbers to strings
    const xDakto22to25Strings = xDakTo22to25.map(num => num.toString())
    setXDakTo([...xDakto22to25Strings, ...processedDakTo])

    const dateTimeArray: string[] = [] // Mảng tạm thời cho dateTime
    // Xử lý từng timestamp và giá trị
    windyDataQuangNgai['ts'].forEach(timestamp => {
      const isoString = new Date(timestamp).toISOString()
      const date = new Date(isoString)

      const year = date.getUTCFullYear()
      const month = String(date.getUTCMonth() + 1).padStart(2, '0')
      const day = String(date.getUTCDate()).padStart(2, '0')
      const hours = String(date.getUTCHours()).padStart(2, '0')
      const minutes = String(date.getUTCMinutes()).padStart(2, '0')

      dateTimeArray.push(`${day}-${month}-${year} ${hours}:${minutes}`)
    })

    setDateTime([...dateArrayStrings, ...dateTimeArray]) // Set state cho dateTime
  }, [])

  console.log(xDakTo, xQuangNgai, dateTime)

  return { xDakTo, xQuangNgai, dateTime } // Trả về giá trị đã xử lý bao gồm dateTime
}
