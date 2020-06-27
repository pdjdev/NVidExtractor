Module GUIModule
    Public Function darkencolor(ByVal c As Color, Optional ByVal percent As Integer = 10) As Color

        Dim rr As Byte = c.R
        Dim gg As Byte = c.G
        Dim bb As Byte = c.B

        Dim r As Integer = rr - Convert.ToInt32(percent * (rr / 100))
        Dim g As Integer = gg - Convert.ToInt32(percent * (gg / 100))
        Dim b As Integer = bb - Convert.ToInt32(percent * (bb / 100))
        Return Color.FromArgb(Math.Min(r, 255), Math.Min(g, 255), Math.Min(b, 255))

    End Function
End Module
