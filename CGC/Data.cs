using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/* segmentsName
0 - "Голова";
1 - "Атланто-затылочный сустав";
2 - "Правое плечо";
3 - "Левое плечо";
4 - "Правый локоть";
5 - "Левый локоть";
6 - "Правое запястье";
7 - "Левое запястье";
8 - "Правая кисть";
9 - "Левая кисть";
10 - "Правое бедро";
11 - "Левое бедро";
12 - "Правое колено";
13 - "Левое колено";
14 - "Правый голеностоп";
15 - "Левый голеностоп";
16 - "Правая пятка";
17 - "Левая пятка";
18 - "Правый носок";
19 - "Левый носок";
20 - "ОТЦ"
 */

/* segmentsMassPercent
0 - "Голова";
1 - "Туловище";
2 - "Правое плечо";
3 - "Левое плечо";
4 - "Правое предплечье";
5 - "Левое предплечье";
6 - "Правая кисть";
7 - "Левая кисть";
8 - "Правое бедро";
9 - "Левое бедро";
10 - "Правая голень";
11 - "Левая голень";
12 - "Правая стопа";
13 - "Левая стопа";
*/

static class ProgramData
{
    static int activeLayer = 0;
    static int layerCount = 500;
    static int segmentsCount = 21;
    static decimal[] segmentsMassPercent;
    static string[] segmentsName;
    static Color[] segmentsColor;
    static Coordinates[] layers;
    static int pointRadius = 4;
    static decimal totalMass = 80;
    static double[] pricsSegment;
    static public CGCCalc clculateClass;
    static public List<int> plusKeys, minusKeys;
    static ProgramData()
    {
        plusKeys = new List<int>();
        minusKeys = new List<int>();
        minusKeys.Add(65);
        minusKeys.Add(97);
        minusKeys.Add(1092);
        minusKeys.Add(1060);
        plusKeys.Add(68);
        plusKeys.Add(100);
        plusKeys.Add(1042);
        plusKeys.Add(1074);
        segmentsName = new string[segmentsCount];
        segmentsColor = new Color[segmentsCount];
        layers = new Coordinates[layerCount];
        pricsSegment = new double[8];
        clculateClass = new CGCCalc();
        for (int i = 0; i < layerCount; i++)
        {
            layers[i] = new Coordinates(i);
        }
        layers[1].SetInUseFlag();
        segmentsMassPercent = new decimal[14];
        segmentsName[0] = "Голова";
        segmentsName[1] = "Атл-зат. сустав";
        segmentsName[2] = "Правое плечо";
        segmentsName[3] = "Левое плечо";
        segmentsName[4] = "Правый локоть";
        segmentsName[5] = "Левый локоть";
        segmentsName[6] = "Правое запястье";
        segmentsName[7] = "Левое запястье";
        segmentsName[8] = "Правая кисть";
        segmentsName[9] = "Левая кисть";
        segmentsName[10] = "Правое бедро";
        segmentsName[11] = "Левое бедро";
        segmentsName[12] = "Правое колено";
        segmentsName[13] = "Левое колено";
        segmentsName[14] = "Правый голеностоп";
        segmentsName[15] = "Левый голеностоп";
        segmentsName[16] = "Правая пятка";
        segmentsName[17] = "Левая пятка";
        segmentsName[18] = "Правый носок";
        segmentsName[19] = "Левый носок";
        segmentsName[20] = "ОТЦ";
        pricsSegment[0] = 0.5;
        pricsSegment[1] = 0.43;
        pricsSegment[2] = 0.45;
        pricsSegment[3] = 0.427;
        pricsSegment[4] = 0;
        pricsSegment[5] = 0.455;
        pricsSegment[6] = 0.405;
        pricsSegment[7] = 0.442;
        SetDefaults();
    }

    public static string[] GetRefSegmentsNameArray()
    {
        return segmentsName;
    }

    public static void IncPointRadius()
    {
        if (pointRadius <= 6)
            pointRadius += 2;
    }

    public static void DecPointRadius()
    {
        if (pointRadius >= 4)
            pointRadius -= 2;
    }

    public static void SetPointRadius(int val)
    {
        pointRadius = 2 * val;
    }

    public static int GetPointRadius()
    {
        return pointRadius / 2;
    }

    public static string GetActiveLayerName()
    {
        return layers[activeLayer].GetLayerName();
    }

    public static void SetPoint(Point pos, int elemNum)
    {
        layers[activeLayer].SetSegmentPosition(pos, elemNum);
    }

    static public void PaintLayer(PaintEventArgs args)
    {
        Point active;
        for (int i = 0; i < segmentsCount - 1; i++)
        {
            active = layers[activeLayer].GetCoordinatesByNum(i);
            if (active.X != -100)
            {
                // e.X + 1, panel1.Height - e.Y - 2
                Pen pen = new Pen(segmentsColor[i]);
                SolidBrush brush = new SolidBrush(segmentsColor[i]);
                args.Graphics.DrawEllipse(pen, active.X - pointRadius,  active.Y - pointRadius, 2 * pointRadius - 1, 2 * pointRadius - 1);
                args.Graphics.DrawEllipse(pen, active.X - pointRadius / 2, active.Y - pointRadius / 2, pointRadius - 1, pointRadius - 1);
                args.Graphics.FillEllipse(brush, active.X - pointRadius / 2,  active.Y - pointRadius / 2, pointRadius - 1, pointRadius - 1);
            }            
        }
        active = layers[activeLayer].GetCoordinatesByNum(20);
        if (active.X != -100)
        {
            // e.X + 1, panel1.Height - e.Y - 2
            Pen pen = new Pen(segmentsColor[20]);
            SolidBrush brush = new SolidBrush(segmentsColor[20]);
            args.Graphics.DrawEllipse(pen, active.X - pointRadius, active.Y - pointRadius, 2 * pointRadius - 1, 2 * pointRadius - 1);
            args.Graphics.FillEllipse(brush, active.X - pointRadius, active.Y - pointRadius, 2 * pointRadius - 1, 2 * pointRadius - 1);
            pen.Width = 1;
            args.Graphics.DrawEllipse(pen, active.X - pointRadius - 3, active.Y - pointRadius - 3, 2 * pointRadius - 1 + 6, 2 * pointRadius - 1 + 6);
            args.Graphics.DrawEllipse(pen, active.X - pointRadius - 5, active.Y - pointRadius - 5, 2 * pointRadius - 1 + 10, 2 * pointRadius - 1 + 10);
        }  
    }

    static public void LoadToSegmentComboBox(ComboBox cb)
    {
        cb.Items.Clear();
        for (int i = 0; i < segmentsCount - 1; i++)
            cb.Items.Add(ProgramData.segmentsName[i]);
        cb.SelectedIndex = 0;
    }

    static public void LoadToColorComboBox(ComboBox cb)
    {
        cb.Items.Clear();
        for (int i = 0; i < segmentsCount; i++)
            cb.Items.Add(ProgramData.segmentsName[i]);
        cb.SelectedIndex = 0;
    }

    static public void ChangePanelColor(Panel pn, int num)
    {
        pn.BackColor = ProgramData.segmentsColor[num];
    }

    static public void DrawPointOnAlf(int selectedSegment, PaintEventArgs alfArgs)
    {
        Pen pen = new Pen(segmentsColor[selectedSegment]);
        SolidBrush brush = new SolidBrush(segmentsColor[selectedSegment]);
        Point active = layers[activeLayer].GetAlfCoordinatesByNum(selectedSegment);
        alfArgs.Graphics.DrawEllipse(pen, active.X - 5, active.Y - 5, 9, 9);
        alfArgs.Graphics.FillEllipse(brush, active.X - 5, active.Y - 5, 9, 9);
    }

    static public void SetDefaults()
    {
        segmentsMassPercent[0] = 6.9m;
        segmentsMassPercent[1] = 43.5m;
        segmentsMassPercent[2] = 2.7m;
        segmentsMassPercent[3] = 2.7m;
        segmentsMassPercent[4] = 1.6m;
        segmentsMassPercent[5] = 1.6m;
        segmentsMassPercent[6] = 0.6m;
        segmentsMassPercent[7] = 0.6m;
        segmentsMassPercent[8] = 14.2m;
        segmentsMassPercent[9] = 14.2m;
        segmentsMassPercent[10] = 4.3m;
        segmentsMassPercent[11] = 4.3m;
        segmentsMassPercent[12] = 1.4m;
        segmentsMassPercent[13] = 1.4m;
        segmentsColor[0] = Color.FromArgb(-65536);
        segmentsColor[1] = Color.FromArgb(-32768);
        segmentsColor[2] = Color.FromArgb(-256);
        segmentsColor[3] = Color.FromArgb(-256);
        segmentsColor[4] = Color.FromArgb(-16711872);
        segmentsColor[5] = Color.FromArgb(-16711872);
        segmentsColor[6] = Color.FromArgb(-16711681);
        segmentsColor[7] = Color.FromArgb(-16711681);
        segmentsColor[8] = Color.FromArgb(-16744193);
        segmentsColor[9] = Color.FromArgb(-16744193);
        segmentsColor[10] = Color.FromArgb(-65281);
        segmentsColor[11] = Color.FromArgb(-65281);
        segmentsColor[12] = Color.FromArgb(-16744320);
        segmentsColor[13] = Color.FromArgb(-16744320);
        segmentsColor[14] = Color.FromArgb(-16777056);
        segmentsColor[15] = Color.FromArgb(-16777056); 
        segmentsColor[16] = Color.FromArgb(-8355840);
        segmentsColor[17] = Color.FromArgb(-8355840);
        segmentsColor[18] = Color.FromArgb(-12582784);
        segmentsColor[19] = Color.FromArgb(-12582784);
        segmentsColor[20] = Color.FromArgb(-16776961);
        pointRadius = 4;
        totalMass = 80;
    }

    static public int GetSegmentsCount()
    {
        return segmentsCount;
    }

    static public void GopySegmentsMassPercent(out decimal[] copy)
    {
        copy = new decimal[14];
        for (int i = 0; i < 14; i++)
        {
            copy[i] = segmentsMassPercent[i];
        }
    }

    static public void SetColorMass(Color[] input)
    {
        for (int i = 0; i < segmentsCount; i++)
            segmentsColor[i] = input[i];
    }

    static public decimal GetTotalMass()
    {
        return totalMass;
    }

    static public void ClearLayer(bool activeLayerFlag)
    {
        if (activeLayerFlag)
        {
            layers[activeLayer].ClearCoordinates();
        }
        else
            for (int i = 0; i < layerCount; i++)
                if (layers[i].GetInUseFlag())
                    layers[i].ClearCoordinates();
    }

    static public void SetSegmentColor(Color newColor, int segmentNum)
    {
        segmentsColor[segmentNum] = newColor;
    }

    static public void CopyColorsArray(out Color[] newColors)
    {
        newColors = new Color[segmentsCount];
        for (int i = 0; i < segmentsCount; i++)
        {
            newColors[i] = segmentsColor[i];
        }
    }

    static public Color[] GetRefSegmetsColorArray()
    {
        return segmentsColor;
    }

    static public void SetSegmentsMassPercentArray(decimal[] input)
    {
        for (int i = 0; i < 14; i++)
        {
            segmentsMassPercent[i] = input[i];
        }
    }

    static public decimal[] GetRefSegmentsMassPercent()
    {
        return segmentsMassPercent;
    }

    static public Color[] GetRefPointColors()
    {
        return segmentsColor;
    }

    static public void SetTotalMass(decimal input)
    {
        totalMass = input;
    }

    static public Point[] GetActiveLayerPointsCoordinates()
    {
        return layers[activeLayer].GetCoordinatesArray();
    }

    static public double[] GetPricsSegments()
    {
        return pricsSegment;
    }

    static public Point GetCGCActiveLayer()
    {
        return layers[activeLayer].GetCGC();
    }

    static public void CGCActiveLayerCalculate()
    {
        ProgramData.layers[activeLayer].SetCGC(clculateClass.CalculateCGC());
    }

    static public bool CheckAllPointSet()
    {
        Point[] check = layers[activeLayer].GetCoordinatesArray();
        for (int i = 0; i < segmentsCount - 1; i++)
        {
            if (check[i].X == -100)
                return false;
        }
        return true;
    }
}

struct PointD
{
    public double X;
    public double Y;
}

class CGCCalc
{
    public PointD[] left;
    public PointD[] right;
    public PointD commonGravityCenter;
    public CGCCalc()
    {
        left = new PointD[8];
        right = new PointD[8];
    }

    /* public void SetControlValues()
    {
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(283, 207), 0);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(289, 192), 1);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(298, 183), 2);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(279, 177), 3);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(320, 161), 4);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(277, 154), 5);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(307, 138), 6);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(256, 152), 7);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(296, 133), 8);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(250, 151), 9);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(300, 129), 10);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(288, 131), 11);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(273, 97), 12);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(300, 84), 13);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(314, 89), 14);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(322, 51), 15);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(322, 98), 16);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(334, 49), 17);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(313, 75), 18);
        ProgramData.layers[ProgramData.activeLayer].SetSegmentPosition(new Point(311, 42), 19);
    } */
    
    public Point CalculateCGC()
    {
        Point[] coordinates = ProgramData.GetActiveLayerPointsCoordinates();
        double[] pricsSegment = ProgramData.GetPricsSegments();
        double[] segMassPrecent = new double[14]; 
        double totalMass = Convert.ToDouble(ProgramData.GetTotalMass());
        decimal[] temp = ProgramData.GetRefSegmentsMassPercent();
        for(int i = 0; i < 14; i++)
            segMassPrecent[i] = Convert.ToDouble(temp[i]);
        //Начало рассчета;
        right[0].X = coordinates[0].X; //Голова, правое, X;
        right[0].Y = coordinates[0].Y; //Голова, правое, Y;
        right[1].X = ((coordinates[2].X + coordinates[3].X) / 2.0) - ((((coordinates[2].X + coordinates[3].X) / 2.0) - ((coordinates[10].X + coordinates[11].X) / 2.0)) * pricsSegment[1]); //Туловище, Парвое, X;
        right[1].Y = ((coordinates[2].Y + coordinates[3].Y) / 2.0) - ((((coordinates[2].Y + coordinates[3].Y) / 2.0) - ((coordinates[10].Y + coordinates[11].Y) / 2.0)) * pricsSegment[1]); //Туловище, Правое, Y;
        right[2].X = coordinates[2].X - ((coordinates[2].X - coordinates[4].X) * pricsSegment[2]); // Плечо, Правое, X;
        left[2].X = coordinates[3].X - ((coordinates[3].X - coordinates[5].X) * pricsSegment[2]); // Плечо, Левое, X;
        right[2].Y = coordinates[2].Y - ((coordinates[2].Y - coordinates[4].Y) * pricsSegment[2]); // Плечо, Правое, Y;
        left[2].Y = coordinates[3].Y - ((coordinates[3].Y - coordinates[5].Y) * pricsSegment[2]); // Плечо, Левое, Y;
        right[3].X = coordinates[4].X - ((coordinates[4].X - coordinates[6].X) * pricsSegment[3]); // Предлечье, Правое, X;
        left[3].X = coordinates[5].X - ((coordinates[5].X - coordinates[7].X) * pricsSegment[3]); // Предплечье, Левое, X;
        right[3].Y = coordinates[4].Y - ((coordinates[4].Y - coordinates[6].Y) * pricsSegment[3]); // Предлечье, Правое, Y;
        left[3].Y = coordinates[5].Y - ((coordinates[5].Y - coordinates[7].Y) * pricsSegment[3]); // Предплечье, Левое, Y;
        right[4].X = coordinates[8].X; // Кисть, Правое, X;
        left[4].X = coordinates[9].X; // Кисть, Левое, X;
        right[4].Y = coordinates[8].Y; // Кисть, Правое Y;
        left[4].Y = coordinates[9].Y; // Кисть, Левое, Y;
        right[5].X = coordinates[10].X - ((coordinates[10].X - coordinates[12].X) * pricsSegment[5]); //Бедро, Правое, X;
        left[5].X = coordinates[11].X - ((coordinates[11].X - coordinates[13].X) * pricsSegment[5]); //Бедро, Левое, X;
        right[5].Y = coordinates[10].Y - ((coordinates[10].Y - coordinates[12].Y) * pricsSegment[5]); //Бедро, Правое, Y;
        left[5].Y = coordinates[11].Y - ((coordinates[11].Y - coordinates[13].Y) * pricsSegment[5]); //Бедро, Левое, Y;
        right[6].X = coordinates[12].X - ((coordinates[12].X - coordinates[14].X) * pricsSegment[6]); //Голень, Правое, X;
        left[6].X = coordinates[13].X - ((coordinates[13].X - coordinates[15].X) * pricsSegment[6]); //Голень, Левое, X;
        right[6].Y = coordinates[12].Y - ((coordinates[12].Y - coordinates[14].Y) * pricsSegment[6]); //Голень, Правое, Y;
        left[6].Y = coordinates[13].Y - ((coordinates[13].Y - coordinates[15].Y) * pricsSegment[6]); //Голень, Левое, Y;
        right[7].X = coordinates[16].X - ((coordinates[16].X - coordinates[18].X) * pricsSegment[7]); //Пятка, Правое, X;
        left[7].X = coordinates[17].X - ((coordinates[17].X - coordinates[19].X) * pricsSegment[7]); //Пятка, Правое, X;
        right[7].Y = coordinates[16].Y - ((coordinates[16].Y - coordinates[18].Y) * pricsSegment[7]); //Пятка, Правое, X;
        left[7].Y = coordinates[17].Y - ((coordinates[17].Y - coordinates[19].Y) * pricsSegment[7]); //Пятка, Правое, X;
        commonGravityCenter.X = (segMassPrecent[0] * right[0].X + 
                                 segMassPrecent[1] * right[1].X + 
                                 segMassPrecent[2] * right[2].X +
                                 segMassPrecent[3] * left[2].X + 
                                 segMassPrecent[4] * right[3].X + 
                                 segMassPrecent[5] * left[3].X + 
                                 segMassPrecent[6] * right[4].X + 
                                 segMassPrecent[7] * left[4].X + 
                                 segMassPrecent[8] * right[5].X + 
                                 segMassPrecent[9] * left[5].X + 
                                 segMassPrecent[10] * right[6].X + 
                                 segMassPrecent[11] * left[6].X + 
                                 segMassPrecent[12] * right[7].X + 
                                 segMassPrecent[13] * left[7].X) / 100;
        commonGravityCenter.Y = (segMassPrecent[0] * right[0].Y +
                                 segMassPrecent[1] * right[1].Y +
                                 segMassPrecent[2] * right[2].Y +
                                 segMassPrecent[3] * left[2].Y +
                                 segMassPrecent[4] * right[3].Y +
                                 segMassPrecent[5] * left[3].Y +
                                 segMassPrecent[6] * right[4].Y +
                                 segMassPrecent[7] * left[4].Y +
                                 segMassPrecent[8] * right[5].Y +
                                 segMassPrecent[9] * left[5].Y +
                                 segMassPrecent[10] * right[6].Y +
                                 segMassPrecent[11] * left[6].Y +
                                 segMassPrecent[12] * right[7].Y +
                                 segMassPrecent[13] * left[7].Y) / 100;
        return new Point(Convert.ToInt32(Math.Round(commonGravityCenter.X)), Convert.ToInt32(Math.Round(commonGravityCenter.Y)));
    }
}

class Coordinates
{
    Point[] segmentsPos;
    Point[] picturePos;
    bool inUse;
    string name;
    public Coordinates(int num)
    {
        segmentsPos = new Point[21];
        for (int i = 0; i < 21; i++)
        {
            segmentsPos[i].X = -100;
            segmentsPos[i].Y = -100;            
        }
        name = "Новый слой " + Convert.ToString(num + 1);
        //Координаты точек на теле Альфа;
        picturePos = new Point[20];
        picturePos[0] = new Point(80, 15); //"Голова";
        picturePos[1] = new Point(81, 38); //"Атланто-затылочный сустав";
        picturePos[2] = new Point(66, 44); //"Правое плечо";
        picturePos[3] = new Point(91, 51); //"Левое плечо";
        picturePos[4] = new Point(47, 58); //"Правый локоть";
        picturePos[5] = new Point(95, 74); //"Левый локоть";
        picturePos[6] = new Point(53, 78); //"Правое запястье";
        picturePos[7] = new Point(96, 97); //"Левое запястье";
        picturePos[8] = new Point(49, 87); //"Правая кисть";
        picturePos[9] = new Point(95, 108); //"Левая кисть";
        picturePos[10] = new Point(62, 95); //"Правое бедро";
        picturePos[11] = new Point(80, 96); //"Левое бедро";
        picturePos[12] = new Point(69, 133); //"Правое колено";
        picturePos[13] = new Point(86, 131); //"Левое колено";
        picturePos[14] = new Point(74, 176); //"Правый голеностоп";
        picturePos[15] = new Point(97, 175); //"Левый голеностоп";
        picturePos[16] = new Point(77, 188); //"Правая пятка";
        picturePos[17] = new Point(97, 189); //"Левая пятка";
        picturePos[18] = new Point(60, 190); //"Правый носок";
        picturePos[19] = new Point(104, 189); //"Левый носок";
        inUse = false;
    }

    public Point GetCGC()
    {
        return segmentsPos[20];
    }

    public String GetLayerName()
    {
        return name;
    }

    public void SetSegmentPosition(Point pos, int elemNum)
    {
        segmentsPos[elemNum] = pos; 
    }

    public Point GetCoordinatesByNum(int num)
    {
        return segmentsPos[num];
    }

    public Point[] GetCoordinatesArray()
    {
        return segmentsPos;
    }

    public Point GetAlfCoordinatesByNum(int num)
    {
        return picturePos[num];
    }

    public void ClearCoordinates()
    {
        for (int i = 0; i < ProgramData.GetSegmentsCount(); i++)
            if (segmentsPos[i] != new Point(-100, -100))
                segmentsPos[i] = new Point(-100, -100);
    }

    public bool GetInUseFlag()
    {
        return inUse;
    }

    public void SetInUseFlag()
    {
        inUse = true;
    }

    public void SetCGC(Point cgc)
    {
        segmentsPos[20].X = cgc.X;
        segmentsPos[20].Y = cgc.Y;
    }
}