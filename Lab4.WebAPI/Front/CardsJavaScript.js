function gr(obj, m) {
	var r = 100 * (Number(m) + 1)
	s += ((obj.elements[0])[m]).text + '\r\n'
	obj.restext.value = s
	sum += r
	obj.res.value = String(m)
}
